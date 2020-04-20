using DigitalCV.Data.Domain;
using DigitalCV.Data.Domain.Models;
using DigitalCV.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DigitalCV.Data.Repositories
{
    public class ComputerTechnologyRepository : IComputerTechnologyRepository
    {
        private readonly DigitalCVContext _context;

        public ComputerTechnologyRepository(DigitalCVContext context)
        {
            _context = context;
        }

        public List<ComputerTechnology> GetAllComputerTechnologies()
        {
            return _context.ComputerTechnologies.ToList();
        }
    }
}
