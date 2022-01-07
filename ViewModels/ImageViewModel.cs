using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatColor.Models;

namespace WhatColor.ViewModels
{
    public class ImageViewModel
    {
        //public int ImageID { get; set; }
        //public string FileName { get; set; }
        //public string Contents { get; set; }
        //public byte[] Img { get; set; }
        public List<Image> Images { get; set; }
        public IFormFile Image { get; set; }
    }
}
