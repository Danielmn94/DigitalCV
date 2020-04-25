using AutoMapper;
using DigitalCV.Data.Domain.Models;
using DigitalCV.Data.Interfaces;
using DigitalCV.DTO.DTOs;
using DigitalCV.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Service.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly IGenericRepository<Certificate> _genericRepository;
        private readonly IMapper _mapper;

        public CertificateService(IGenericRepository<Certificate> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public List<CertificateDTO> GetCertificates()
        {
            var certificates = _genericRepository.GetAll();

            var orderedCertificate = certificates.OrderBy(c => c.CertificateName);

            return _mapper.Map<List<CertificateDTO>>(orderedCertificate);
        }

        public CertificateDTO GetCertificateFromID(int id)
        {
            var certificate = _genericRepository.GetById(id);

            return _mapper.Map<CertificateDTO>(certificate);
        }

        public void CreateCertificate(CertificateDTO model)
        {
            var convertedModel = _mapper.Map<Certificate>(model);

            convertedModel.Added = DateTime.Now;

            _genericRepository.Create(convertedModel);
        }

        public void UpdateCertificate(CertificateDTO model)
        {
            var convertedModel = _mapper.Map<Certificate>(model);

            _genericRepository.Update(convertedModel);
        }

        public void DeleteCertificate(int id)
        {
            _genericRepository.Delete(id);
        }
    }
}
