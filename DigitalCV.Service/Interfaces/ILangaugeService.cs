using DigitalCV.DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Service.Interfaces
{
    public interface ILangaugeService
    {
        List<LanguageDTO> GetLanguages();

        LanguageDTO GetLanguageFromID(int id);

        void CreateLanguage(LanguageDTO model);

        void UpdateLanguage(LanguageDTO model);

        void DeleteLanguage(int id);
    }
}
