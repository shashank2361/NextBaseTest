﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextBaseTest.Controllers
{
    public class HomeController : Controller
    {

        [Route("Home/Index")]
        public IActionResult Index()
        {


            return View();
        }
    }
}
