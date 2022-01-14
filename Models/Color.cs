using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatColor.Models
{
    public class Color
    {
        public int ColorID { get; set; }
        public string HEX { get; set; }
        public string CMYK { get; set; }
        public string RGB { get; set; }
        public string Name { get; set; }
        public string TrendingUrl { get; set; }
        public string ComplementaryHex { get; set; }
        public int ColorCategoryID { get; set; }

        //meer op meer
        public ICollection<ColorHistory> ColorHistories { get; set; }





    }
}