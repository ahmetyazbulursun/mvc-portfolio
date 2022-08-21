using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using my_website.Models.Entity;

namespace my_website.Controllers
{

    [AllowAnonymous]

    public class HomeController : Controller
    {

        Entities db = new Entities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tbl_Messages p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            p.DATE = DateTime.Now;
            p.STATUS = true;
            db.Tbl_Messages.Add(p);

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult PageCover()
        {
            var value = db.Tbl_About.ToList();
            return PartialView(value);
        }

        public PartialViewResult About()
        {
            var value = db.Tbl_About.ToList();
            return PartialView(value);
        }

        public PartialViewResult Education()
        {
            var value = db.Tbl_Education.ToList();
            return PartialView(value);
        }

        public PartialViewResult Skills()
        {
            var value = db.Tbl_Skills.ToList();
            return PartialView(value);
        }

        public PartialViewResult Experience()
        {
            var value = db.Tbl_Experience.ToList();
            return PartialView(value);
        }

        public PartialViewResult Projects()
        {
            var value = db.Tbl_Projects.ToList();
            return PartialView(value);
        }

        public PartialViewResult ProjectCategories()
        {
            var value = db.Tbl_ProjectCategories.ToList();
            return PartialView(value);
        }

        public ActionResult ProjectDetail(int id)
        {
            var value = db.Tbl_ProjectImages.Where(x => x.PROJECTID == id).ToList();

            var projectHeader = db.Tbl_Projects.Where(x => x.ID == id).First();
            ViewBag.projectHeader = projectHeader.HEADER;

            return View(value);
        }

        public PartialViewResult Contact()
        {
            var value = db.Tbl_Contact.ToList();
            return PartialView(value);
        }

        public PartialViewResult Certificate()
        {
            var value = db.Tbl_Certificate.ToList();
            return PartialView(value);
        }

        public PartialViewResult Accounts()
        {
            var value = db.Tbl_Accounts.ToList();
            return PartialView(value);
        }
        



    }
}