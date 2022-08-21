using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using my_website.Models.Entity;

namespace my_website.Controllers
{

    [AllowAnonymous]

    public class LoginController : Controller
    {

        Entities db = new Entities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Tbl_Admin p)
        {
            var value = db.Tbl_Admin.FirstOrDefault(x => x.USERNAME == p.USERNAME && x.PASSWORD == p.PASSWORD);

            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.USERNAME, false);
                Session["USERNAME"] = value.USERNAME.ToString();
                return RedirectToAction("About", "Admin");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }
}