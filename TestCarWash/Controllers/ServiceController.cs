using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TestCarWash.Content.Common;
using TestCarWash.Models;

namespace TestCarWash.Controllers
{
    public class ServiceController : Controller
    {
        private CarWashContext db = new CarWashContext();

        public ActionResult Index()
        {
            var services = db.Services.ToList();
            return View(services);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Description, PricePerMinute")] Service service)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Services.Add(service);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error
                ModelState.AddModelError("", PageStrings.CreateErrorMessageText);
            }
            return View(service);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Description, PricePerMinute")] Service service)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(service).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error
                ModelState.AddModelError("", PageStrings.EditErrorMessageText);
            }
            return View(service);
        }

        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = PageStrings.DeleteErrorMessageText;
            }
            var service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var serviceToDelete = new Service { Id = id };
                db.Entry(serviceToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (DataException)
            {
                //Log the error
                return RedirectToAction("Delete", new { Id = id, saveChangesError = true });
            }
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
