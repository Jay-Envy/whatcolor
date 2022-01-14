using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatColor.Data;
using WhatColor.Helpers;
using WhatColor.Models;
using WhatColor.ViewModels;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WhatColor.Controllers
{
    public class ColorController : Controller
    {
        private readonly WhatColorContext _context;
        public List<ColorCategory> ColorCategories;

        public ColorController(WhatColorContext context)
        {
            _context = context;
        }

        public IActionResult Color()
        {
            ColorViewModel viewModel = new ColorViewModel
            {
                Colors = _context.Colors.ToList()
            };
            return View(viewModel);
        }

        public async Task<IActionResult> ColorDetail(int? id)
        {
            if (id == null)
                return NotFound();

            var color = await _context.Colors.FindAsync(id);
            if (color == null)
                return NotFound();

            ColorDetailViewModel viewModel = new ColorDetailViewModel()
            {
                ColorID = color.ColorID,
                Name = color.Name,
                CMYK = color.CMYK,
                HEX = color.HEX,
                RGB = color.RGB,
                ComplementaryHex = color.ComplementaryHex,
                TrendingUrl = color.TrendingUrl
            }
        }

        [Authorize]
        public IActionResult Create()
        {
            CreateColorViewModel viewModel = new CreateColorViewModel
            {
                ColorCategories = _context.ColorCategories.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateColorViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //Kleuren zouden berekend worden door ColorTransformer
                //Met ColorTransformer heb je enkel de naam en de hex-code nodig.
                //De rest wordt vanuit deze twee properties getransformeerd
                //**Deze commentaar is verouderd. Ik heb van alle variabelen strings gemaakt (met meer tijd zou ik het (denk ik) uiteindelijk wel werkende gekregen hebben)**

                string Name = viewModel.Name;
                string HEX = viewModel.HEX;
                string RGB = viewModel.RGB;
                string CMYK = viewModel.CMYK;
                string TrendingUrl = $"https://www.coolors.co/palettes/trending/{HEX}";
                string ComplementaryHex = viewModel.ComplementaryHex;
                int ColorCategoryID = viewModel.ColorCategoryID;
                _context.Add(new Color()
                {
                    Name = Name,
                    HEX = HEX,
                    RGB = RGB,
                    CMYK = CMYK,
                    TrendingUrl = TrendingUrl,
                    ComplementaryHex = ComplementaryHex,
                    ColorCategoryID = ColorCategoryID
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Color));
            }
            return View("Color", viewModel);
        }
    }
}