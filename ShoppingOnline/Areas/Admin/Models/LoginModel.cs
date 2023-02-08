﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingOnline.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập Username!")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Mời nhập Password!")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}