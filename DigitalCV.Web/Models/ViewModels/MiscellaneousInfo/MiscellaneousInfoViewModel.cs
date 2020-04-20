using DigitalCV.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Web.Models.ViewModels.MiscellaneousInfo
{
    public class MiscellaneousInfoViewModel
    {
        public List<LanguageDTO> Languages { get; set; }

        public List<CertificateDTO> Certificates { get; set; }
    }
}
