using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Web.Models.ViewModels.WorkExperience
{
    public class WorkExperienceViewModel
    {
        public string TimePeriod { get; set; }

        public string NameOfCompany { get; set; }

        public string WorkingAs { get; set; }

        public string[] KeyAreasSplitted { get; set; }
    }
}
