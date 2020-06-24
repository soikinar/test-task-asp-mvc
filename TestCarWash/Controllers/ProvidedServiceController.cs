using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TestCarWash.Content.Common;
using TestCarWash.Models;
using TestCarWash.Reports.ReportGenerators;
using TestCarWash.Reports.ReportProviders;
using TestCarWash.ViewModels;

namespace TestCarWash.Controllers
{
    public class ProvidedServiceController : Controller
    {
        private CarWashContext db = new CarWashContext();

        public ActionResult Index(int? clientId)
        {
            var viewModel = new ProvidedServicesIndexData
            {
                Clients = db.Clients
                    .Include(c => c.ProvidedServices.Select(ps => ps.Service))
                    .ToList()
            };
            if (clientId != null)
            {
                ViewBag.ClientId = clientId.Value;
                var providedServices = viewModel.Clients.Single(c => c.Id == clientId).ProvidedServices;
                viewModel.ProvidedServicesByDate = providedServices.GroupBy(ps => ps.ServiceDate.Date);
            }
            return View(viewModel);
        }

        public ActionResult Create(int? clientId)
        {
            if (clientId != null)
            {
                PopulateClientsDropDownList(clientId.Value);
            }
            else
            {
                PopulateClientsDropDownList();
            }
            PopulateServicesDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServiceDate,NumberOfMinutes,ClientId,ServiceId")] ProvidedService providedService)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.ProvidedServices.Add(providedService);
                    db.SaveChanges();
                    return RedirectToAction("Index", new { clientId = providedService.ClientId });
                }
            }
            catch (RetryLimitExceededException)
            {
                //Log the error
                ModelState.AddModelError("", PageStrings.CreateErrorMessageText);
            }
            PopulateClientsDropDownList(providedService.ClientId);
            PopulateServicesDropDownList(providedService.ServiceId);
            return View(providedService);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var providedService = db.ProvidedServices.Find(id);
            if (providedService == null)
            {
                return HttpNotFound();
            }
            PopulateClientsDropDownList(providedService.ClientId);
            PopulateServicesDropDownList(providedService.ServiceId);
            return View(providedService);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ServiceDate,NumberOfMinutes,ClientId,ServiceId")] ProvidedService providedService)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(providedService).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", new { clientId = providedService.ClientId });
                }
            }
            catch (DataException)
            {
                //Log the error
                ModelState.AddModelError("", PageStrings.EditErrorMessageText);
            }
            PopulateClientsDropDownList(providedService.ClientId);
            PopulateServicesDropDownList(providedService.ServiceId);
            return View(providedService);
        }

        public ActionResult Delete(int? id, bool? saveChangesError = null)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = PageStrings.DeleteErrorMessageText;
            }
            var providedService = db.ProvidedServices.Find(id);
            if (providedService == null)
            {
                return HttpNotFound();
            }
            return View(providedService);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            int clientId;
            try
            {
                var providedServiceToDelete = db.ProvidedServices.Find(id);
                clientId = providedServiceToDelete.ClientId;
                db.Entry(providedServiceToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (DataException)
            {
                //Log the error
                return RedirectToAction("Delete", new { Id = id, saveChangesError = true });
            }
            return RedirectToAction("Index", new { clientId = clientId });
        }

        public ActionResult CreateAndPrintReportForClient(int? clientId, DateTime? serviceDate)
        {
            if (clientId == null || serviceDate == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var client = db.Clients
                .Include(c => c.ProvidedServices.Select(ps => ps.Service))
                .SingleOrDefault(c => c.Id == clientId);

            if (client == null)
            {
                return HttpNotFound();
            }
            if (!client.ProvidedServices.Any())
            {
                return new EmptyResult();
            }

            var createdReportPath = CreateProvidedServicesReport(client, serviceDate.Value);
            var createdReportVirtualPath = ConvertPhysicalPathToVirtual(createdReportPath);
            return File(Server.MapPath(createdReportVirtualPath), "application/pdf");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private void PopulateClientsDropDownList(object selectedClient = null)
        {
            var clientsQuery = from client in db.Clients
                orderby client.Person
                select client;
            ViewBag.ClientId = new SelectList(clientsQuery, "Id", "Person", selectedClient);
        }

        private void PopulateServicesDropDownList(object selectedService = null)
        {
            var servicesQuery = from service in db.Services
                orderby service.Name
                select service;
            ViewBag.ServiceId = new SelectList(servicesQuery, "Id", "Name", selectedService);
        }

        private string CreateProvidedServicesReport(Client client, DateTime serviceDate)
        {
            var reportProvider = new InDesignReportProvider();
            var reportGenerator = new ProvidedServicesReportGenerator(reportProvider, client, serviceDate);
            return reportGenerator.CreateReportFromTemplate();
        }

        private string ConvertPhysicalPathToVirtual(string physicalPath)
        {
            return physicalPath.Replace(Request.ServerVariables["APPL_PHYSICAL_PATH"], "~/").Replace(@"\", "/");
        }
    }
}
