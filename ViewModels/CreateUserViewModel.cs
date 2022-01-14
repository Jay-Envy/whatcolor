using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WhatColor.ViewModels
{
    public class CreateUserViewModel
    {

        public string Id { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
