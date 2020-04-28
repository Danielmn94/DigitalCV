using DigitalCV.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Service.Interfaces
{
    public interface ICertificateService
    {
        List<CertificateDTO> GetCertificates();

        CertificateDTO GetCertificateFromID(int id);

        void CreateCertificate(CertificateDTO model);

        void UpdateCertificate(CertificateDTO model);

        void DeleteCertificate(int id);
    }
}
