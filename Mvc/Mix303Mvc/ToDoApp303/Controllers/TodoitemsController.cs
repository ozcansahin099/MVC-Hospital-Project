using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDoApp303.Models;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace ToDoApp303.Controllers
{
    [Authorize]
    public class TodoitemsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Todoitems
        public async Task<ActionResult> Index()
        {
           
            var todoitems = db.Todoitems.Include(t => t.Category).Include(t => t.Customer).Include(t => t.Department).Include(t => t.Manager).Include(t => t.Side);
            return View(await todoitems.ToListAsync());
        }

        // GET: Todoitems/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todoitem todoitem = await db.Todoitems.FindAsync(id);
            if (todoitem == null)
            {
                return HttpNotFound();
            }
            return View(todoitem);
        }

        // GET: Todoitems/Create
        public ActionResult Create()
        {
            var todoitem = new Todoitem();
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name");
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            ViewBag.ManagerId = new SelectList(db.Contacts, "Id", "FirstName");
            ViewBag.SideId = new SelectList(db.Sides, "Id", "Name");
            return View(todoitem);
        }

        // POST: Todoitems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,Status,CategoryId,Attachment,DepartmentId,SideId,CustomerId,ManagerId,OrganizatorId,MeetingDate,PlannedDate,FinishDate,ReviseDate,ConversationSubject,SupporterCompany,SupporterDoctor,ConversationAttendeeCount,ScheduledOrganizationDate,MaillingSubjects,PosterSubject,PosterCount,Elearning,TypeofScans,AsoCountInScans,TypeOfOrganization,AsoCountInOrganizations,TypeOfVaccinationOrganization,AsoCountInVaccinationOrganization,AmountOfCompansationForPoster,CorporateProductivityReport,CreateDate,CreatedBy,UpdateDate,UpdateBy")] Todoitem todoitem)
        {
            if (ModelState.IsValid)
            {
                todoitem.CreateDate = DateTime.Now;
                todoitem.CreatedBy = User.Identity.Name;
                todoitem.UpdateDate = DateTime.Now;
                todoitem.UpdateBy = User.Identity.Name;
                db.Todoitems.Add(todoitem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", todoitem.CategoryId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", todoitem.CustomerId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", todoitem.DepartmentId);
            ViewBag.ManagerId = new SelectList(db.Contacts, "Id", "FirstName", todoitem.ManagerId);
            ViewBag.SideId = new SelectList(db.Sides, "Id", "Name", todoitem.SideId);
            return View(todoitem);
        }

        // GET: Todoitems/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todoitem todoitem = await db.Todoitems.FindAsync(id);
            if (todoitem == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", todoitem.CategoryId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", todoitem.CustomerId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", todoitem.DepartmentId);
            ViewBag.ManagerId = new SelectList(db.Contacts, "Id", "FirstName", todoitem.ManagerId);
            ViewBag.SideId = new SelectList(db.Sides, "Id", "Name", todoitem.SideId);
            return View(todoitem);
        }

        // POST: Todoitems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Description,Status,CategoryId,Attachment,DepartmentId,SideId,CustomerId,ManagerId,OrganizatorId,MeetingDate,PlannedDate,FinishDate,ReviseDate,ConversationSubject,SupporterCompany,SupporterDoctor,ConversationAttendeeCount,ScheduledOrganizationDate,MaillingSubjects,PosterSubject,PosterCount,Elearning,TypeofScans,AsoCountInScans,TypeOfOrganization,AsoCountInOrganizations,TypeOfVaccinationOrganization,AsoCountInVaccinationOrganization,AmountOfCompansationForPoster,CorporateProductivityReport,CreateDate,CreatedBy,UpdateDate,UpdateBy")] Todoitem todoitem)
        {
            if (ModelState.IsValid)
            {
                todoitem.UpdateDate = DateTime.Now;
                todoitem.UpdateBy = User.Identity.Name;
                db.Entry(todoitem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", todoitem.CategoryId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Name", todoitem.CustomerId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", todoitem.DepartmentId);
            ViewBag.ManagerId = new SelectList(db.Contacts, "Id", "FirstName", todoitem.ManagerId);
            ViewBag.SideId = new SelectList(db.Sides, "Id", "Name", todoitem.SideId);
            return View(todoitem);
        }

        // GET: Todoitems/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todoitem todoitem = await db.Todoitems.FindAsync(id);
            if (todoitem == null)
            {
                return HttpNotFound();
            }
            return View(todoitem);
        }

        // POST: Todoitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Todoitem todoitem = await db.Todoitems.FindAsync(id);
            db.Todoitems.Remove(todoitem);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public void ExportToExcel()
        {
            var grid = new GridView();
            grid.DataSource = from s in db.Todoitems.ToList()
                              select new
                              {
                                  Baslik = s.Title,
                                  Aciklama = s.Description,
                                  Kategori = s.Category.Name,
                                  DosyaEki = s.Attachment,
                                  Departman = s.Department.Name,
                                  Taraf = s.Side.Name,
                                  Musteri = s.Customer.Name,
                                  Yonetici = s.Manager.FirstName + ' ' + s.Manager.LastName,
                                  Organizator = s.Organizator.FirstName + " " + s.Organizator.LastName,
                                  Durum = s.Status,
                                  ToplantiTarihi = s.MeetingDate,
                                  PlanlamaTarihi = s.PlannedDate,
                                  BitirilmeTarihi = s.FinishDate,
                                  RevizeTarihi = s.ReviseDate,
                                  GorusmeKonusu = s.ConversationSubject,
                                  DestekleyenFirma = s.SupporterCompany,
                                  DestekleyenHekim = s.SupporterDoctor,
                                  GorusmeKatiliciSayisi = s.ConversationAttendeeCount,
                                  PlanlananOrganizasyonTarihi = s.ScheduledOrganizationDate,
                                  MailKonulari = s.MaillingSubjects,
                                  AfisKonusu = s.PosterSubject,
                                  AfisSayisi = s.PosterCount,
                                  UzaktanEgitim = s.Elearning,
                                  YapilanTaramalarinTurleri = s.TypeofScans,
                                  YapilanTaramalardakiAsoSayisi = s.AsoCountInScans,
                                  OrganizasyonTurleri = s.TypeOfOrganization,
                                  OrganizasyondakiAsoSayisi = s.AsoCountInOrganizations,
                                  AsiOrganizasyonTurleri = s.TypeOfVaccinationOrganization,
                                  AsiOrganizasyondakiAsoSayisi = s.AsoCountInVaccinationOrganization,
                                  AfisicinTazminatMiktar = s.AmountOfCompansationForPoster,
                                  KurumsalVerimlilikRaporu = s.CorporateProductivityReport,
                                  OlusturulmaTarihi = s.CreateDate,
                                  OlusturanKullanici = s.CreatedBy,
                                  GuncellemeTarihi = s.UpdateDate,
                                  GuncelleyenKullanici = s.UpdateBy,

                              };

            grid.DataBind();
            Response.Clear();
            var sure = DateTime.Now.Day + DateTime.Now.ToString()+DateTime.Now.Year.ToString();
            Response.AddHeader("content_Disposition", $"attachment,filename=yapilacaklar{sure}.xls");
            Response.ContentType = "application/ms-excel";
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grid.RenderControl(hw);
            Response.Write(sw.ToString());
            Response.End();
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
