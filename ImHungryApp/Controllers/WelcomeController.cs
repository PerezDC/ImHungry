using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImHungryApp.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: Welcome
        public ActionResult Index()
        {
            return View();
        }

        // GET: Welcome/Search
        public ActionResult Search()
        {
            return View();
        }

        // GET: Welcome/Reveal
        public ActionResult Reveal()
        {
            return View();
        }

        // GET: Welcome/Results
        public ActionResult Results()
        {
            return View();
        }
    }
}