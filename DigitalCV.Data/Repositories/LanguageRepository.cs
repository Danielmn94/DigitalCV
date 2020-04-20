using DigitalCV.Data.Domain;
using DigitalCV.Data.Domain.Models;
using DigitalCV.Data.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DigitalCV.Data.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly DigitalCVContext _context;

        public LanguageRepository(DigitalCVContext context)
        {
            _context = context;
        }

        public List<Language> GetLanguages()
        {
            return _context.Languages.ToList();
        }
    }
}
