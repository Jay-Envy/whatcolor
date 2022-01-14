﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WhatColor.Models;

namespace WhatColor.ViewModels
{
    public class CreateColorViewModel
    {
        public int ColorID { get; set; }
        public string HEX { get; set; }
        public string CMYK { get; set; }
        public string RGB { get; set; }
        public string Name { get; set; }
        public string TrendingUrl { get; set; }
        public string ComplementaryHex { get; set; }
        public int ColorCategoryID { get; set; }
        public List<ColorCategory> ColorCategories { get; set; }
    }
}
