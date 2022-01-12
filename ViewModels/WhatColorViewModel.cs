﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatColor.Models;

namespace WhatColor.ViewModels
{
    public class WhatColorViewModel
    {
        public List<Color> Colors { get; set; }
        public string ColorSearch { get; set; }
    }
}