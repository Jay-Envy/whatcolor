using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WhatColor.Models
{
    public class Image
    {
        //public int ImageID { get; set; }
        //public string ImagePath { get; set; }
        ////public Int64 BLOB { get; set; }
        //public string FileName { get; set; }

        public int ImageID { get; set; }
        public string FileName { get; set; }
        [AllowHtml]
        public string Contents { get; set; }
        public byte[] Img { get; set; }
        public ICollection<ImageLibrary> ImageLibraries { get; set; }
    }
}
