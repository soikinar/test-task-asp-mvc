using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TestCarWash.Content.Common;
using TestCarWash.Models;
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
                viewModel.ProvidedServices = viewModel.Clients.Single(c => c.Id == clientId).ProvidedServices;
            }
            return View(viewModel);
        }

        public ActionResult Create()
        {
            PopulateClientsDropDownList();
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

        // GET: ProvidedService/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvidedService providedService = db.ProvidedServices.Find(id);
            if (providedService == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Person", providedService.ClientId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name", providedService.ServiceId);
            return View(providedService);
        }

        // POST: ProvidedService/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ServiceDate,NumberOfMinutes,ClientId,ServiceId")] ProvidedService providedService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(providedService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Person", providedService.ClientId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name", providedService.ServiceId);
            return View(providedService);
        }

        // GET: ProvidedService/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvidedService providedService = db.ProvidedServices.Find(id);
            if (providedService == null)
            {
                return HttpNotFound();
            }
            return View(providedService);
        }

        // POST: ProvidedService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProvidedService providedService = db.ProvidedServices.Find(id);
            db.ProvidedServices.Remove(providedService);
            db.SaveChanges();
            return RedirectToAction("Index");
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
    }
}
