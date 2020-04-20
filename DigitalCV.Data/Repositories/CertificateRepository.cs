﻿using DigitalCV.Data.Domain;
using DigitalCV.Data.Domain.Models;
using DigitalCV.Data.Interfaces;
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

        public List<Certificate> GetCertificates()
        {
            return _context.Certificates.ToList();
        }
    }
}
