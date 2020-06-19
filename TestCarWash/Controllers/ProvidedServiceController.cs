using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TestCarWash.Models;
using TestCarWash.ViewModels;

namespace TestCarWash.Controllers
{
    public class ProvidedServiceController : Controller
    {
        private CarWashContext db = new CarWashContext();

        //public ActionResult Index()
        //{
        //    var providedServices = db.ProvidedServices
        //        .Include(p => p.Client)
        //        .Include(p => p.Service)
        //        .ToList();
        //    return View(providedServices);
        //}

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

        // GET: ProvidedService/Details/5
        public ActionResult Details(int? id)
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

        // GET: ProvidedService/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Person");
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name");
            return View();
        }

        // POST: ProvidedService/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ServiceDate,NumberOfMinutes,ClientId,ServiceId")] ProvidedService providedService)
        {
            if (ModelState.IsValid)
            {
                db.ProvidedServices.Add(providedService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Person", providedService.ClientId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Name", providedService.ServiceId);
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
    }
}
