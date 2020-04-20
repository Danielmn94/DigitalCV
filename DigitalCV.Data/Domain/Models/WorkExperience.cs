using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Data.Domain.Models
{
    public class WorkExperience
    {
        [Key]
        public int ID { get; set; }

        public DateTime? Updated { get; set; }

        public DateTime Added { get; set; }

        public string TimePeriod { get; set; }

        public string NameOfCompany { get; set; }

        public string WorkingAs { get; set; }

        public string KeyAreas { get; set; }
    }
}
