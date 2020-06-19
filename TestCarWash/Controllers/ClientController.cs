using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TestCarWash.Content.Common;
using TestCarWash.Models;

namespace TestCarWash.Controllers
{
    public class ClientController : Controller
    {
        private CarWashContext db = new CarWashContext();

        public ActionResult Index()
        {
            var clients = db.Clients.ToList();
            return View(clients);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = db.Clients
                .Include(c => c.ProvidedServices.Select(s => s.Service))
                .FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Person, PhoneNumber")] Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Clients.Add(client);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error
                ModelState.AddModelError("", PageStrings.CreateErrorMessageText);
            }
            return View(client);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Person, PhoneNumber")] Client client)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(client).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                //Log the error
                ModelState.AddModelError("", PageStrings.EditErrorMessageText);
            }
            return View(client);
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
            var client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var clientToDelete = new Client { Id = id };
                db.Entry(clientToDelete).State = EntityState.Deleted;
                db.SaveChanges();
            }
            catch (DataException)
            {
                //Log the error
                return RedirectToAction("Delete", new {Id = id, saveChangesError = true});
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
