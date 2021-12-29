using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatColor.Data;
using WhatColor.Models;
using WhatColor.ViewModels;

namespace WhatColor.Controllers
{
    public class ColorController : Controller
    {
        public List<Color> colors;
        public ColorController()
        {
            colors = new List<Color>();
        }
        public IActionResult Index()
        {
            ColorViewModel viewModel = new ColorViewModel();
            viewModel.Colors = colors;
            return View(viewModel);
        }
        public IActionResult Search(ColorViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.ColorSearch))
            {
                viewModel.Colors = colors.Where(b => b.HEX.Contains(viewModel.ColorSearch)).ToList();
            }
            else
            {
                viewModel.Colors = colors;
            }
            return View("Color", viewModel);
        }
        private readonly WhatColorContext _context;

        public ColorController(WhatColorContext context)
        {
            _context = context;
        }
    }
}
