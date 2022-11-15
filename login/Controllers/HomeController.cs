using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using login.Models;

namespace login.Controllers
{
    public class HomeController : Controller
    {
        db dbop = new db();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index([Bind] ad_login ad)
        {
            int res = dbop.logincheck(ad);
            if(res == 1)
            {
                TempData["msg"] = "you are welcome to admin section";
            }
            else
            {
                TempData["msg"] = "incurrect id or password";
            }
            return View();
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