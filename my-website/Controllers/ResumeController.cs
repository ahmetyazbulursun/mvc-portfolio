using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using my_website.Models.Entity;

namespace my_website.Controllers
{

    [AllowAnonymous]

    public class ResumeController : Controller
    {

        Entities db = new Entities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult About()
        {
            var value = db.Tbl_About.ToList();
            return PartialView(value);
        }

        public PartialViewResult Accounts()
        {
            var value = db.Tbl_Accounts.ToList();
            return PartialView(value);
        }

        public PartialViewResult Education()
        {
            var value = db.Tbl_Education.ToList();
            return PartialView(value);
        }

        public PartialViewResult Interests()
        {
            var value = db.Tbl_Interests.ToList();
            return PartialView(value);
        }

        public PartialViewResult CareerProfile()
        {
            var value = db.Tbl_About.ToList();
            return PartialView(value);
        }

        public PartialViewResult Experiences()
        {
            var value = db.Tbl_Experience.ToList();
            return PartialView(value);
        }

        public ActionResult Projects()
        {
            var value = db.Tbl_Projects.ToList();
            return PartialView(value);
        }

        public PartialViewResult SkillsAndProficiency()
        {
            var value = db.Tbl_Skills.ToList();
            return PartialView(value);
        }

    }
}