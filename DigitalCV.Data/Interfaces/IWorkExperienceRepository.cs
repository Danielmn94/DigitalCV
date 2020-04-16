using DigitalCV.Data.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Data.Interfaces
{
    public interface IWorkExperienceRepository
    {
        List<WorkExperience> GetWorkExperiences();
    }
}
