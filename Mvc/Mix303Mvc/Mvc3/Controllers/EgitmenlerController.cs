using Mvc3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Mvc3.Controllers
{
    public class EgitmenlerController : Controller
    {
        MixContext db = new MixContext();
        private int httpStatusCode;

        // GET: Egitmenler
        public ActionResult Index()
        {
            var egitmen = db.egitmenlers.ToList();
            return View(egitmen);
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Egitmenler egitmenler = db.egitmenlers.Find(id);
            if (egitmenler == null)
            {
                return HttpNotFound();
            }
            return View(egitmenler);
        }

        public ActionResult Create()
        {
            var egitmenler = new Egitmenler();
            ViewBag.BransId = new SelectList(db.brans, "Id", "BransAdi");
            return View(egitmenler);
        }
        [HttpPost]
        public  ActionResult Create(Egitmenler egitmenler)
        {
            if (ModelState.IsValid)
            {
                db.egitmenlers.Add(egitmenler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BransId = new SelectList(db.brans, "Id", "BransAdi", egitmenler.BransId);
            return View(egitmenler);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Egitmenler egitmenler = db.egitmenlers.Find(id);
            if (egitmenler == null)
            {
                return HttpNotFound();
            }
            ViewBag.BransId = new SelectList(db.brans, "Id", "BransAdi", egitmenler.BransId);
            return View(egitmenler);
        }
        [HttpPost]
        public ActionResult Edit(Egitmenler egitmenler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(egitmenler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BransId = new SelectList(db.brans, "Id", "BransAdi", egitmenler.BransId);
            return View(egitmenler);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Egitmenler egitmenler = db.egitmenlers.Find(id);
            if (egitmenler == null)
            {
                return HttpNotFound();
            }
           
            return View(egitmenler);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComfirmed(int id)
        {
            Egitmenler egitmenler = db.egitmenlers.Find(id);
            db.egitmenlers.Remove(egitmenler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
    }
}