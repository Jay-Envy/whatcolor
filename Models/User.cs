using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhatColor.Models
{
    public class User : IdentityUser
    {
        //Andere props komen uit baseklasse IdentityUser
        public string Country { get; set; }

        //Meer op meer
        public ICollection<ColorHistory> ColorHistories { get; set; }
        public ICollection<ImageLibrary> ImageLibraries { get; set; }
    }
}