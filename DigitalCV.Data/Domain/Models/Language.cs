using DigitalCV.Data.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Data.Domain.Models
{
    public class Language : BaseEntity
    {
        public string LanguageText { get; set; }

        public string LevelOfLanguage { get; set; }
    }
}
