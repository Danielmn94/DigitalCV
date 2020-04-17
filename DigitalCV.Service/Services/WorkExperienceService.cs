using AutoMapper;
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
    public class WorkExperienceService : IWorkExperienceService
    {
        private readonly IWorkExperienceRepository _workRepository;
        private readonly IMapper _mapper;

        public WorkExperienceService(IWorkExperienceRepository workRepository, IMapper mapper)
        {
            _workRepository = workRepository;
            _mapper = mapper;
        }

        public List<WorkExperienceDTO> GetWorkExperiences()
        {
            var workExperiences = _workRepository.GetWorkExperiences();

            var orderedWorkExperiences = workExperiences.OrderByDescending(x => x.TimePeriod);

            return _mapper.Map<List<WorkExperienceDTO>>(orderedWorkExperiences);
        }
    }
}
