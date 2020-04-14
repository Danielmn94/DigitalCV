using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Data.Domain.Models
{
    public class Education
    {
        public DateTime Updated { get; set; }
        public DateTime Added { get; set; }
        public string TimePeriod { get; set; }
        [Key]
        public string NameOfEducation { get; set; }
        public string School { get; set; }
    }
}
