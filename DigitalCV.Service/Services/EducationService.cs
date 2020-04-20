using AutoMapper;
using DigitalCV.Data.Interfaces;
using DigitalCV.DTO.DTOs;
using DigitalCV.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DigitalCV.Service.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;

        public EducationService(IEducationRepository educationRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public List<EducationDTO> GetEducations()
        {
            var educations = _educationRepository.GetEducations();

            var orderedList = educations.OrderByDescending(x => x.TimePeriod);

            return _mapper.Map<List<EducationDTO>>(orderedList);
        }
    }
}
