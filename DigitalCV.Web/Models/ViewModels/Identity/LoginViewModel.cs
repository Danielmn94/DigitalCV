﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Web.Models.ViewModels.Identity
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Brugernavn er påkrævet")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Adgangskode er påkrævet")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
