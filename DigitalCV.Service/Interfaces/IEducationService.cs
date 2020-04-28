using DigitalCV.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Service.Interfaces
{
    public interface IEducationService
    {
        List<EducationDTO> GetEducations();

        EducationDTO GetEducationFromID(int id);

        void CreateEducation(EducationDTO model);

        void UpdateEducation(EducationDTO model);

        void DeleteEducation(int id);
    }
}
