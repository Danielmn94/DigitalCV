using DigitalCV.Data.Domain;
using DigitalCV.Data.Domain.Models;
using DigitalCV.Data.Interfaces;
using DigitalCV.DTO.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DigitalCV.Data.Repositories
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly DigitalCVContext _context;

        public CertificateRepository(DigitalCVContext context)
        {
            _context = context;
        }

        List<CertificateDTO> ICertificateRepository.GetCertificates()
        {
            throw new System.NotImplementedException();
        }
    }
}
