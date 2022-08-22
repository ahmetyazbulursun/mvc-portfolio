using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using my_website.Models.Entity;

namespace my_website.Controllers
{
    public class AdminController : Controller
    {

        Entities db = new Entities();

        public ActionResult Index()
        {
            return View();
        }

        // |-----------About Operations----------->
        public ActionResult About()
        {
            var value = db.Tbl_About.ToList();
            return View(value);
        }

        public ActionResult AboutUpdate(int id)
        {
            var value = db.Tbl_About.Find(id);
            return View("AboutUpdate", value);
        }

        public ActionResult AboutUpdateAction(Tbl_About p)
        {
            var value = db.Tbl_About.Find(p.ID);

            value.FULLNAME = p.FULLNAME;
            value.IMAGE = p.IMAGE;
            value.IMAGE2 = p.IMAGE2;
            value.RESUMEIMAGE = p.RESUMEIMAGE;
            value.JOB = p.JOB;
            value.DETAIL = p.DETAIL;

            db.SaveChanges();
            return RedirectToAction("About");
        }
        // <----------End About Operations-----------|

        // |-----------Account Operations----------->
        public ActionResult Accounts()
        {
            var value = db.Tbl_Accounts.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddAccount()
        {
            List<SelectListItem> icon = (from x in db.Tbl_AccountIcons.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.NAME,
                                             Value = x.ID.ToString()
                                         }
                                         ).ToList();

            ViewBag.Icon = icon;

            return View();
        }

        [HttpPost]
        public ActionResult AddAccount(Tbl_Accounts p)
        {
            var icon = db.Tbl_AccountIcons.Where(x => x.ID == p.Tbl_AccountIcons.ID).FirstOrDefault();

            p.Tbl_AccountIcons = icon;

            db.Tbl_Accounts.Add(p);
            db.SaveChanges();
            return RedirectToAction("Accounts");
        }

        public ActionResult AccountUpdate(int id)
        {
            var value = db.Tbl_Accounts.Find(id);

            List<SelectListItem> icon = (from x in db.Tbl_AccountIcons.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.NAME,
                                             Value = x.ID.ToString()
                                         }
                                         ).ToList();

            ViewBag.Icon = icon;

            return View("AccountUpdate", value);
        }

        public ActionResult AccountUpdateAction(Tbl_Accounts p)
        {
            var value = db.Tbl_Accounts.Find(p.ID);
            var icon = db.Tbl_AccountIcons.Where(x => x.ID == p.Tbl_AccountIcons.ID).FirstOrDefault();


            value.ICONID = icon.ID;
            value.NAME = p.NAME;
            value.LINK = p.LINK;

            db.SaveChanges();
            return RedirectToAction("Accounts");
        }

        public ActionResult AccountDelete(int id)
        {
            var value = db.Tbl_Accounts.Find(id);
            db.Tbl_Accounts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Accounts");
        }
        // <----------End Account Operations-----------|

        // |-----------Admin Operations----------->
        public ActionResult Admin()
        {
            var value = db.Tbl_Admin.ToList();
            return View(value);
        }

        public ActionResult AdminUpdate(int id)
        {
            var value = db.Tbl_Admin.Find(id);
            return View("AdminUpdate", value);
        }

        public ActionResult AdminUpdateAction(Tbl_Admin p)
        {
            var value = db.Tbl_Admin.Find(p.ID);

            value.USERNAME = p.USERNAME;
            value.PASSWORD = p.PASSWORD;

            db.SaveChanges();
            return RedirectToAction("Admin");
        }
        // <----------End Admin Operations-----------|

        // |-----------Certificate Operations----------->
        public ActionResult Certificates()
        {
            var value = db.Tbl_Certificate.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCertificate(Tbl_Certificate p)
        {
            db.Tbl_Certificate.Add(p);
            db.SaveChanges();
            return RedirectToAction("Certificates");
        }

        public ActionResult CertificateDelete(int id)
        {
            var value = db.Tbl_Certificate.Find(id);
            db.Tbl_Certificate.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Certificates");
        }

        public ActionResult CertificateUpdate(int id)
        {
            var value = db.Tbl_Certificate.Find(id);
            return View("CertificateUpdate", value);
        }

        public ActionResult CertificateUpdateAction(Tbl_Certificate p)
        {
            var value = db.Tbl_Certificate.Find(p.ID);

            value.NAME = p.NAME;
            value.LINK = p.LINK;

            db.SaveChanges();
            return RedirectToAction("Certificates");
        }


        // |-----------Contact Operations----------->
        public ActionResult Contact()
        {
            var value = db.Tbl_Contact.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult ContactUpdate(int id)
        {
            var value = db.Tbl_Contact.Find(id);
            return View("ContactUpdate", value);
        }

        [HttpPost]
        public ActionResult ContactUpdate(Tbl_Contact p)
        {
            var value = db.Tbl_Contact.Find(p.ID);

            value.PHONE = p.PHONE;
            value.MAIL = p.MAIL;
            value.ADRESS = p.ADRESS;

            db.SaveChanges();
            return RedirectToAction("Contact");
        }
        // <----------End Contact Operations-----------|

        // |-----------Education Operations----------->
        public ActionResult Education()
        {
            var value = db.Tbl_Education.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEducation(Tbl_Education p)
        {
            db.Tbl_Education.Add(p);
            db.SaveChanges();
            return RedirectToAction("Education");
        }

        public ActionResult EducationDelete(int id)
        {
            var value = db.Tbl_Education.Find(id);
            db.Tbl_Education.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Education");
        }

        public ActionResult EducationUpdate(int id)
        {
            var value = db.Tbl_Education.Find(id);
            return View("EducationUpdate", value);
        }

        public ActionResult EducationUpdateAction(Tbl_Education p)
        {
            var value = db.Tbl_Education.Find(p.ID);

            value.DEPARTMENT = p.DEPARTMENT;
            value.SCHOOL = p.SCHOOL;
            value.STARTDATE = p.STARTDATE;
            value.ENDDATE = p.ENDDATE;

            db.SaveChanges();
            return RedirectToAction("Education");
        }

        // |-----------Experience Operations----------->
        public ActionResult Experiences()
        {
            var value = db.Tbl_Experience.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExperience(Tbl_Experience p)
        {
            db.Tbl_Experience.Add(p);
            db.SaveChanges();
            return RedirectToAction("Experiences");
        }

        public ActionResult ExperienceDelete(int id)
        {
            var value = db.Tbl_Experience.Find(id);
            db.Tbl_Experience.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Experiences");
        }

        public ActionResult ExperienceUpdate(int id)
        {
            var value = db.Tbl_Experience.Find(id);
            return View("ExperienceUpdate", value);
        }

        public ActionResult ExperienceUpdateAction(Tbl_Experience p)
        {
            var value = db.Tbl_Experience.Find(p.ID);

            value.HEADER = p.HEADER;
            value.COMPANYNAME = p.COMPANYNAME;
            value.STARTDATE = p.STARTDATE;
            value.ENDDATE = p.ENDDATE;
            value.DETAIL = p.DETAIL;

            db.SaveChanges();
            return RedirectToAction("Experiences");
        }
        // <----------End Experience Operations-----------|

        // |-----------Interest Operations----------->
        public ActionResult Interests()
        {
            var value = db.Tbl_Interests.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddInterest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInterest(Tbl_Interests p)
        {
            db.Tbl_Interests.Add(p);
            db.SaveChanges();
            return RedirectToAction("Interests");
        }

        public ActionResult InterestDelete(int id)
        {
            var value = db.Tbl_Interests.Find(id);
            db.Tbl_Interests.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Interests");
        }

        public ActionResult InterestUpdate(int id)
        {
            var value = db.Tbl_Interests.Find(id);
            return View("InterestUpdate", value);
        }

        public ActionResult InterestUpdateAction(Tbl_Interests p)
        {
            var value = db.Tbl_Interests.Find(p.ID);

            value.INTEREST = p.INTEREST;

            db.SaveChanges();
            return RedirectToAction("Interests");
        }
        // <----------End Interest Operations-----------|

        // |-----------Message Operations----------->
        public ActionResult Messages()
        {
            var value = db.Tbl_Messages.Where(x => x.STATUS == true).ToList();
            return View(value);
        }

        public ActionResult MessageDetail(int id)
        {
            var value = db.Tbl_Messages.Find(id);
            return View("MessageDetail", value);
        }

        public ActionResult MessageRead(Tbl_Messages p)
        {
            var value = db.Tbl_Messages.Find(p.ID);

            value.STATUS = false;

            db.SaveChanges();
            return RedirectToAction("Messages");
        }
        // <----------End Message Operations-----------|

        // |-----------Project Operations----------->
        public ActionResult Projects()
        {
            var value = db.Tbl_Projects.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            List<SelectListItem> category = (from x in db.Tbl_ProjectCategories.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.NAME,
                                                 Value = x.ID.ToString()
                                             }
                                             ).ToList();

            ViewBag.Category = category;

            return View();
        }

        [HttpPost]
        public ActionResult AddProject(Tbl_Projects p)
        {
            var category = db.Tbl_ProjectCategories.Where(x => x.ID == p.Tbl_ProjectCategories.ID).FirstOrDefault();

            p.Tbl_ProjectCategories = category;

            db.Tbl_Projects.Add(p);
            db.SaveChanges();
            return RedirectToAction("Projects");
        }

        public ActionResult ProjectDelete(int id)
        {
            var value = db.Tbl_Projects.Find(id);
            db.Tbl_Projects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Projects");
        }

        [HttpGet]
        public ActionResult ProjectImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProjectImage(Tbl_ProjectImages p)
        {
            var project = db.Tbl_Projects.Find(p.ID);

            p.PROJECTID = project.ID;
            db.Tbl_ProjectImages.Add(p);
            db.SaveChanges();
            return RedirectToAction("Projects");
        }

        public ActionResult ProjectImages(int id)
        {
            var value = db.Tbl_ProjectImages.Where(x => x.PROJECTID == id).ToList();
            return View("ProjectImages", value);
        }

        public ActionResult ProjectImageDelete(int id)
        {
            var value = db.Tbl_ProjectImages.Find(id);
            db.Tbl_ProjectImages.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Projects");
        }

        [HttpGet]
        public ActionResult ProjectUpdate(int id)
        {
            var value = db.Tbl_Projects.Find(id);

            List<SelectListItem> category = (from x in db.Tbl_ProjectCategories
                                             select new SelectListItem
                                             {
                                                 Text = x.NAME,
                                                 Value = x.ID.ToString()
                                             }
                                                   ).ToList();

            ViewBag.Category = category;

            return View("ProjectUpdate", value);
        }

        [HttpPost]
        public ActionResult ProjectUpdate(Tbl_Projects p)
        {
            var value = db.Tbl_Projects.Find(p.ID);
            var category = db.Tbl_ProjectCategories.Where(x => x.ID == p.Tbl_ProjectCategories.ID).FirstOrDefault();

            value.CATEGORYID = category.ID;
            value.HEADER = p.HEADER;
            value.IMAGE = p.IMAGE;
            value.GITHUB = p.GITHUB;

            db.SaveChanges();
            return RedirectToAction("Projects");
        }
        // <----------End Project Operations-----------|

        // |-----------Skill Operations----------->
        public ActionResult Skills()
        {
            var value = db.Tbl_Skills.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(Tbl_Skills p)
        {
            db.Tbl_Skills.Add(p);
            db.SaveChanges();
            return RedirectToAction("Skills");
        }

        public ActionResult SkillDelete(int id)
        {
            var value = db.Tbl_Skills.Find(id);
            db.Tbl_Skills.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Skills");
        }

        public ActionResult SkillUpdate(int id)
        {
            var value = db.Tbl_Skills.Find(id);
            return View("SkillUpdate", value);
        }

        public ActionResult SkillUpdateAction(Tbl_Skills p)
        {
            var value = db.Tbl_Skills.Find(p.ID);

            value.SKILL = p.SKILL;
            value.VALUE = p.VALUE;

            db.SaveChanges();
            return RedirectToAction("Skills");
        }
        // <----------End Skill Operations-----------|





    }
}