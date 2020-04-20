using DigitalCV.Data.Domain.Models;
using System.Collections.Generic;

namespace DigitalCV.Data.Interfaces
{
    public interface IWorkExperienceRepository
    {
        List<WorkExperience> GetWorkExperiences();
    }
}
