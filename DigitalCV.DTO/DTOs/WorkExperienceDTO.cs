﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.DTO.DTOs
{
    public class WorkExperienceDTO
    {
        public int Id { get; set; }

        public string TimePeriod { get; set; }

        public string NameOfCompany { get; set; }

        public string WorkingAs { get; set; }

        public string KeyAreas { get; set; }
    }
}
