﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.DTO.DTOs
{
    public class RegisterDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
