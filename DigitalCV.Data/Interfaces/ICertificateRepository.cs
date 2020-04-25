using DigitalCV.Data.Domain.Models;
using DigitalCV.DTO.DTOs;
using System.Collections.Generic;

namespace DigitalCV.Data.Interfaces
{
    public interface ICertificateRepository
    {
        List<CertificateDTO> GetCertificates();
    }
}
