using DigitalCV.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Service.Interfaces
{
    public interface IWorkExperienceService
    {
        List<WorkExperienceDTO> GetWorkExperiences();

        WorkExperienceDTO GetWorkExperienceFromID(int id);

        void CreateWorkExperience(WorkExperienceDTO model);

        void UpdateWorkExperience(WorkExperienceDTO model);

        void DeleteWorkExperience(int id);
    }
}
