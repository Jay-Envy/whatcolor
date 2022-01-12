using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatColor.Models
{
    public class ColorHistory
    {
        public int ColorHistoryID { get; set; }
        public int ColorID { get; set; }
        public string Id { get; set; }
        public DateTime SearchDate { get; set; }
        public Color Color { get; set; }
        public User User { get; set; }
    }
}
