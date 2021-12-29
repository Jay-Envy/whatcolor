using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatColor.ViewModels;
using WhatColor.Models;
using WhatColor.Controllers;

namespace WhatColor.Controllers
{
    public class WhatColorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Result(string naam, int aantal = 1)
        {
            ViewData["Message"] = "Hallo " + naam;
            ViewData["Aantal"] = aantal;
            return View();
        }


    }
}