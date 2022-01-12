using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WhatColor.Data;
using WhatColor.Models;
using WhatColor.ViewModels;


namespace WhatColor.Controllers
{
    public class ImageController : Controller
    {
        private readonly WhatColorContext _context;
        public List<Image> images;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageController(WhatColorContext context, IWebHostEnvironment webHostEnvironment)
        {
            images = new List<Image>();
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Image()
        {
            ImageViewModel viewModel = new ImageViewModel
            {
                Images = _context.Images.ToList()
            };
            return View(await _context.Images.ToListAsync());
        }

        public IActionResult Create()
        {
            ImageViewModel viewmodel = new ImageViewModel();
            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ImageViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(viewmodel.Image.FileName);
                string fileExtension = Path.GetExtension(viewmodel.Image.FileName);

                string fullPath = Path.Combine(webRootPath + "/Images/", viewmodel.Image.FileName);
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await viewmodel.Image.CopyToAsync(fileStream);
                }

                _context.Add(viewmodel.Image);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }

            return View("Images", viewmodel);
        }
    }
}
