using DigitalCV.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Web.Models.ViewModels.Education
{
    public class EducationViewModel
    {
        public string AspController { get; set; }

        public string AspAction { get; set; }

        public string ButttonText { get; set; }

        public int Id { get; set; }

        public string TimePeriod { get; set; }

        public string NameOfEducation { get; set; }

        public string School { get; set; }
    }
}
