using DigitalCV.Data.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Data.Domain.Models
{
    public class Education : BaseEntity
    {
        public string TimePeriod { get; set; }

        public string NameOfEducation { get; set; }

        public string School { get; set; }
    }
}
