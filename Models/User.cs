using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatColor.Models
{
    public class User
    {
        public int userID { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string country { get; set; }
    }
}