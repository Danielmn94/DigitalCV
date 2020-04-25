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
    public class EducationService : IEducationService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Education> _genericRepository;

        public EducationService(IMapper mapper, IGenericRepository<Education> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        public List<EducationDTO> GetEducations()
        {   
            var educations = _genericRepository.GetAll();

            var orderedList = educations.OrderByDescending(x => x.TimePeriod);

            return _mapper.Map<List<EducationDTO>>(orderedList);
        }

        public EducationDTO GetEducationFromID(int id)
        {
            var education = _genericRepository.GetById(id);

            return _mapper.Map<EducationDTO>(education);
        }

        public void CreateEducation(EducationDTO model)
        {
            var convertedModel = _mapper.Map<Education>(model);

            convertedModel.Added = DateTime.Now;

            _genericRepository.Create(convertedModel);
        }

        public void UpdateEducation(EducationDTO model)
        {
            var added = _genericRepository.GetAdded(model.Id);

            var convertedModel = _mapper.Map<Education>(model);

            convertedModel.Updated = DateTime.Now;
            convertedModel.Added = added;

            _genericRepository.Update(convertedModel);
        }

        public void DeleteEducation(int id)
        {
            _genericRepository.Delete(id);
        }
    }
}
