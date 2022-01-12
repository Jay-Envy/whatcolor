using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatColor.Models;

namespace WhatColor.ViewModels
{
    public class ImageLibraryViewModel
    {
        public int ImageLibraryID { get; set; }
        public string Id { get; set; }
        public int ImageID { get; set; }
        public List<Image> Images { get; set; }
    }
}
