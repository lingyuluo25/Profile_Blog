using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMVCProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome to Lynn's Personal Blog.";
            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Details";

            return View();
        }
    }
}