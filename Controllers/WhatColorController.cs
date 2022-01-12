using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatColor.ViewModels;
using WhatColor.Models;
using WhatColor.Controllers;
using Microsoft.AspNetCore.Authorization;
using WhatColor.Data;
using Microsoft.EntityFrameworkCore;

namespace WhatColor.Controllers
{
    public class WhatColorController : Controller
    {
        private readonly WhatColorContext _context;
        public WhatColorController(WhatColorContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Search(WhatColorViewModel viewModel)
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
    }
}