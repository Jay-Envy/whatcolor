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
        //public List<Color> colors;
        public List<ColorCategory> ColorCategories;

        public ColorController(WhatColorContext context)
        {
            //colors = new List<Color>();
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

        public async Task<IActionResult> Search(ColorViewModel viewModel)
        {

            if (!string.IsNullOrEmpty(viewModel.ColorSearch))
            {
                viewModel.Colors = await _context.Colors.Where(b => b.HEX.Contains(viewModel.ColorSearch)).ToListAsync();
            }
            else
            {
                viewModel.Colors = await _context.Colors.ToListAsync();
            }
            return View("Color", viewModel);

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
                //Kleuren worden berekend door ColorTransformer
                //string Name = viewModel.Name;
                //string HEX = viewModel.HEX;
                //string RGB = Convert.ToInt32(HEX, 16).ToString();
                //string CMYK = ColorTransformer.GetCMYK(RGB).ToString();
                //string TrendingUrl = $"https://www.coolors.co/trending/{HEX}";
                //string ComplementaryHex = ColorTransformer.GetComplementaryHex(RGB);


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