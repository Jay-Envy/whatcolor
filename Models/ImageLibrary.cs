using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatColor.Models
{
    public class ImageLibrary
    {
        public int ImageLibraryID { get; set; }
        public int ImageID { get; set; }
        public string Id { get; set; }
        public Image Image { get; set; }
        public User User { get; set; }
    }
}
