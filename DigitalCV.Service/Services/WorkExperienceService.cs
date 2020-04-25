using AutoMapper;
using DigitalCV.Data.Domain.Models;
using DigitalCV.Data.Interfaces;
using DigitalCV.DTO.DTOs;
using DigitalCV.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitalCV.Service.Services
{
    public class WorkExperienceService : IWorkExperienceService
    {
        private readonly IGenericRepository<WorkExperience> _genericRepository;
        private readonly IMapper _mapper;

        public WorkExperienceService(IGenericRepository<WorkExperience> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public List<WorkExperienceDTO> GetWorkExperiences()
        {
            var workExperiences = _genericRepository.GetAll();

            var orderedWorkExperiences = workExperiences.OrderByDescending(x => x.TimePeriod);

            return _mapper.Map<List<WorkExperienceDTO>>(orderedWorkExperiences);
        }

        public WorkExperienceDTO GetWorkExperienceFromID(int id)
        {
            var workExperience = _genericRepository.GetById(id);

            return _mapper.Map<WorkExperienceDTO>(workExperience);
        }

        public void CreateWorkExperience(WorkExperienceDTO model)
        {
            var convertedModel = _mapper.Map<WorkExperience>(model);

            convertedModel.Added = DateTime.Now;

            _genericRepository.Create(convertedModel);
        }

        public void UpdateWorkExperience(WorkExperienceDTO model)
        {
            var convertedModel = _mapper.Map<WorkExperience>(model);

            _genericRepository.Update(convertedModel);
        }

        public void DeleteWorkExperience(int id)
        {
            _genericRepository.Delete(id);
        }
    }
}
