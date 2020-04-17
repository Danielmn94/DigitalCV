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
    public class ComputerTechnologyService : IComputerTechnologyService
    {
        private readonly IMapper _mapper;
        private readonly IComputerTechnologyRepository _computerTechnologyRepository;

        public ComputerTechnologyService(IMapper mapper, IComputerTechnologyRepository computerTechnologyRepository)
        {
            _mapper = mapper;
            _computerTechnologyRepository = computerTechnologyRepository;
        }

        public List<ComputerTechnologyDTO> GetWorkExperiences()
        {
            var computerTechnologies = _computerTechnologyRepository.GetAllComputerTechnologies();

            var orderedComputerTechnologies = computerTechnologies.OrderBy(x => x.ITGroup);

            return _mapper.Map<List<ComputerTechnologyDTO>>(orderedComputerTechnologies);
        }
    }
}
