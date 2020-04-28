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
    public class ComputerTechnologyService : IComputerTechnologyService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ComputerTechnology> _genericRepository;

        public ComputerTechnologyService(IMapper mapper, IGenericRepository<ComputerTechnology> genericRepository)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        public List<ComputerTechnologyDTO> GetComputerTechnologies()
        {
            var computerTechnologies = _genericRepository.GetAll();

            var orderedComputerTechnologies = computerTechnologies.OrderBy(x => x.ITGroup);

            return _mapper.Map<List<ComputerTechnologyDTO>>(orderedComputerTechnologies);
        }

        public ComputerTechnologyDTO GetComputerTechnologyFromID(int id)
        {
            var computerTechnology = _genericRepository.GetById(id);

            return _mapper.Map<ComputerTechnologyDTO>(computerTechnology);
        }

        public void CreateComputerTechnology(ComputerTechnologyDTO model)
        {
            var convertedModel = _mapper.Map<ComputerTechnology>(model);

            convertedModel.Added = DateTime.Now;

            _genericRepository.Create(convertedModel);
        }

        public void UpdateComputerTechnology(ComputerTechnologyDTO model)
        {
            var added = _genericRepository.GetAdded(model.Id);

            var convertedModel = _mapper.Map<ComputerTechnology>(model);

            convertedModel.Updated = DateTime.Now;
            convertedModel.Added = added;

            _genericRepository.Update(convertedModel);
        }

        public void DeleteComputerTechnology(int id)
        {
            _genericRepository.Delete(id);
        }
    }
}
