using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImHungryApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Login()
        {
            return View();
        }
        
        public ViewResult ResetPassword()
        {
            return View();
        }
        
        public ViewResult ResetPasswordSent()
        {
            return View();
        }

        public ViewResult About()
        {
            return View();
        }
    }
}