using DigitalCV.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Service.Interfaces
{
    public interface IComputerTechnologyService
    {
        List<ComputerTechnologyDTO> GetWorkExperiences();
    }
}
