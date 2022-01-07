using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatColor.Data;

namespace WhatColor.Models
{
    public class ColorCategory
    {
        public int ColorCategoryID { get; set; }
        public string MainColor { get; set; }
        public string Positive { get; set; }
        public string Negative { get; set; }
        public string Meaning { get; set; }
    }
}
