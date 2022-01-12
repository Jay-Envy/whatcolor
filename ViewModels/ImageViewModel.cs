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

        public List<Image> Images { get; set; }
        public IFormFile Image { get; set; }
    }
}
