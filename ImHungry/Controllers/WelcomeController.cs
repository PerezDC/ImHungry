﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace ImHungry.Controllers
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