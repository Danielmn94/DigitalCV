using DigitalCV.Data.Domain;
using DigitalCV.Data.Domain.Models;
using DigitalCV.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Data.Repositories
{
    public class WorkExperienceRepository : IWorkExperienceRepository
    {
        private readonly DigitalCVContext _context;

        public WorkExperienceRepository(DigitalCVContext context)
        {
            _context = context;
        }

        public List<WorkExperience> GetWorkExperiences()
        {
            return _context.WorkExperiences.ToList();
        }
    }
}
