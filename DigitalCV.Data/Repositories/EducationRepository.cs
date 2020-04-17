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
    public class EducationRepository : IEducationRepository
    {
        private readonly DigitalCVContext _context;

        public EducationRepository(DigitalCVContext context)
        {
            _context = context;
        }

        public List<Education> GetEducations()
        {
            return _context.Educations.ToList();
        }
    }
}
