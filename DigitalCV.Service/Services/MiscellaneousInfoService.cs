using AutoMapper;
using DigitalCV.Data.Interfaces;
using DigitalCV.DTO.DTOs;
using DigitalCV.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DigitalCV.Service.Services
{
    public class MiscellaneousInfoService : IMiscellaneousInfoService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly ICertificateRepository _certificateRepository;
        private readonly IMapper _mapper;

        public MiscellaneousInfoService(ILanguageRepository languageRepository, ICertificateRepository certificateRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _certificateRepository = certificateRepository;
            _mapper = mapper;
        }

        public List<LanguageDTO> GetLanguages()
        {
            var languages = _languageRepository.GetLanguages();

            var languageDTO =  _mapper.Map<List<LanguageDTO>>(languages);

            return languageDTO.OrderBy(l => l.Language).ToList();
        }

        public List<CertificateDTO> GetCertificate()
        {
            var certificates = _certificateRepository.GetCertificates();

            var orderedCertificate = certificates.OrderBy(c => c.CertificateName);

            return _mapper.Map<List<CertificateDTO>>(orderedCertificate);
        }
    }
}
