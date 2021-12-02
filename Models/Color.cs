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
        public int CMYK { get; set; }
        public int RGB { get; set; }
        public string Name { get; set; }
        public string TrendingUrl { get; set; }
        public string ComplementaryHex { get; set; }

        public int color = Convert.ToInt32("FFFFFF", 16);
    }
}