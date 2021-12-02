using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatColor.ViewModels;
using WhatColor.Models;

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

        public IActionResult Search(WhatColorViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.ColorSearch))
            {
                viewModel.Color = color.Where(b => b.Name.Contains(viewModel.ColorSearch)).ToList();
            }
            else
            {
                viewModel.Color = color;
            }
            return View("Index", viewModel);
        }
    }
}