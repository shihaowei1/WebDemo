﻿using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();  //对应视图中的Home/Index.cshtml
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();  //对应视图中的Home/About.cshtml
        }

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}