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
    public class OgrencilerController : Controller
    {
        private MixContext db = new MixContext();
        // GET: Ogrenciler
        public async Task<ActionResult> Index() //async :data Yükleme ve bilginin gelmesi bu sayede aynı anda olur.
        {
            return View(await db.ogrencilers.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenciler ogrenciler = await db.ogrencilers.FindAsync(id);
            if (ogrenciler == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciler);
        }
        public ActionResult Create()
        {
            var ogrenciler = new Ogrenciler();
            return View(ogrenciler);
        }
        [HttpPost]
        public async Task<ActionResult>Create(Ogrenciler ogrenciler)
        {
            if (ModelState.IsValid)
            {
                db.ogrencilers.Add(ogrenciler);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ogrenciler);   
        }
        public async Task<ActionResult>Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenciler ogrenciler = await db.ogrencilers.FindAsync(id);
            if (ogrenciler == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciler);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Ogrenciler ogrenciler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenciler).State=EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ogrenciler);
        }
        public async Task<ActionResult>Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ogrenciler ogrenciler = await db.ogrencilers.FindAsync(id);
            if (ogrenciler == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciler);
        }

        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ogrenciler ogrenciler = await db.ogrencilers.FindAsync(id);
            db.ogrencilers.Remove(ogrenciler);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
    }
}