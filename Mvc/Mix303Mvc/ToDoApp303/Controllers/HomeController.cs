using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoApp303.Models;

namespace ToDoApp303.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        AppDbContext db = new AppDbContext();
        public ActionResult Index()
        {
            ViewBag.CustomerCount = db.Customers.Count();
            ViewBag.StatusNewCount = db.Todoitems.Count(x => x.Status == Status.New);
            ViewBag.StatusWaitingCount = db.Todoitems.Count(x => x.Status == Status.Waiting);
            ViewBag.StatusCompletedCount = db.Todoitems.Count(x => x.Status == Status.Complated);
            return View();
        }
        public ActionResult Completed()
        {
            var comp = db.Todoitems.Where(x => x.Status == Status.Complated).ToList();
            return View(comp);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}