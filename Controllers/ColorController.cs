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
using Microsoft.AspNetCore.Mvc.Rendering;

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

        [AllowAnonymous]
        public IActionResult Color()
        {
            ColorViewModel viewModel = new ColorViewModel
            {
                Colors = _context.Colors.ToList()
            };
            return View(viewModel);
        }

        [AllowAnonymous]
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
            };
            return View(viewModel);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            CreateColorViewModel viewModel = new CreateColorViewModel
            {
                //ColorCategories = _context.ColorCategories.ToList()
            };
            return View(viewModel);
        }


        //--OPGEPAST-- in deze methode heb ik veel getest, en het ziet er uit als een clusterfuck
        [Authorize(Roles = "admin")]
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

                //ColorID wordt gebruikt voor de "if doesn't exist -> do"
                int ColorID = viewModel.ColorID;

                string Name = viewModel.Name;
                string HEX = viewModel.HEX;
                string RGB = viewModel.RGB;
                string CMYK = viewModel.CMYK;
                string TrendingUrl = $"https://www.coolors.co/palettes/trending/{HEX}";
                string ComplementaryHex = viewModel.ComplementaryHex;
                //int ColorCategoryID = viewModel.ColorCategoryID;

                //Ik wil controleren of de kleur al bestaat -> als de naam en de hex-code niet bestaan, kan deze toegevoegd worden
                //if (_context.Colors.FindAsync(Name) == null && _context.Colors.FindAsync(HEX) == null)
                    _context.Add(new Color()
                    {
                        Name = Name,
                        HEX = HEX,
                        RGB = RGB,
                        CMYK = CMYK,
                        TrendingUrl = TrendingUrl,
                        ComplementaryHex = ComplementaryHex,
                        //ColorCategoryID = ColorCategoryID

                        /*
                         --ColorCategory zou nog een dropdown zijn, maar hier heb ik geen tijd meer voor--

                            <div class="form-group">
                                <label asp-for="ColorCategoryID" class="control-label"></label>
                                <select id="ColorCategories" name="ColorCategories">
                                    @foreach (var item in Model.ColorCategories)
                                    {
                                        <option>
                                            @item.MainColor
                                        </option>
                                    }
                                </select>
                                <span asp-validation-for="ColorCategoryID" class="text-danger"></span>
                            </div>
                         */
                    });
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Color));
                //}
                //else
                //    return RedirectToAction("Color");
            }
            return View("Color", viewModel);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var color = await _context.Colors.FirstOrDefaultAsync(c => c.ColorID == id);
            if (color == null)
                return NotFound();

            DeleteColorViewModel viewModel = new DeleteColorViewModel()
            {
                ColorID = color.ColorID,
                Name = color.Name,
                HEX = color.HEX,
                RGB = color.RGB,
                CMYK = color.CMYK,
                TrendingUrl = color.TrendingUrl,
                ComplementaryHex = color.ComplementaryHex,
                ColorCategoryID = color.ColorCategoryID
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var color = await _context.Colors.FindAsync(id);
            _context.Colors.Remove(color);
            await _context.SaveChangesAsync();
            return RedirectToAction("Color");
        }

        [HttpGet]
        public async Task<IActionResult> Search(ColorViewModel viewModel)
        {

            if (!string.IsNullOrEmpty(viewModel.ColorSearch))
            {
                viewModel.Colors = await _context.Colors.Where(c => c.HEX.Contains(viewModel.ColorSearch)).ToListAsync();
            }
            else
            {
                viewModel.Colors = await _context.Colors.ToListAsync();
            }
            return View("Color", viewModel);

        }
    }
}