using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Data.Domain.Models
{
    public class Certificate
    {
        public DateTime Updated { get; set; }
        public DateTime Added { get; set; }
        [Key]
        public string CertificateName { get; set; }
    }
}
