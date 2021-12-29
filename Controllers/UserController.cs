using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatColor.Models;
using WhatColor.ViewModels;

namespace WhatColor.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Users()
        {
            return View();
        }
    }
}