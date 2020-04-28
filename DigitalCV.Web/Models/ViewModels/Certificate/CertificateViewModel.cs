using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Web.Models.ViewModels.Certificate
{
    public class CertificateViewModel
    {
        public string AspController { get; set; }

        public string AspAction { get; set; }

        public string ButttonText { get; set; }

        public int Id { get; set; }

        public string CertificateName { get; set; }
    }
}
