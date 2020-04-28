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
    public class LanguageService : ILangaugeService
    {
        private readonly IGenericRepository<Language> _genericRepository;
        private readonly IMapper _mapper;

        public LanguageService(IGenericRepository<Language> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public List<LanguageDTO> GetLanguages()
        {
            var languages = _genericRepository.GetAll();

            var languageDTO =  _mapper.Map<List<LanguageDTO>>(languages);

            return languageDTO.OrderBy(l => l.LanguageText).ToList();
        }

        public LanguageDTO GetLanguageFromID(int id)
        {
            var language = _genericRepository.GetById(id);

            return _mapper.Map<LanguageDTO>(language);
        }

        public void CreateLanguage(LanguageDTO model)
        {
            var convertedModel = _mapper.Map<Language>(model);

            convertedModel.Added = DateTime.Now;

            _genericRepository.Create(convertedModel);
        }

        public void UpdateLanguage(LanguageDTO model)
        {
            var added = _genericRepository.GetAdded(model.Id);

            var convertedModel = _mapper.Map<Language>(model);

            convertedModel.Updated = DateTime.Now;
            convertedModel.Added = added;

            _genericRepository.Update(convertedModel);
        }

        public void DeleteLanguage(int id)
        {
            _genericRepository.Delete(id);
        }
    }
}
