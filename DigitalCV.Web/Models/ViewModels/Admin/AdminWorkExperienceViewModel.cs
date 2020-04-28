using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Web.Models.ViewModels.Admin
{
    public class AdminWorkExperienceViewModel
    {
        public string AspController { get; set; }

        public string AspAction { get; set; }

        public string ButttonText { get; set; }

        public int Id { get; set; }

        public string TimePeriod { get; set; }

        public string NameOfCompany { get; set; }

        public string WorkingAs { get; set; }

        public string KeyAreas { get; set; }
    }
}
