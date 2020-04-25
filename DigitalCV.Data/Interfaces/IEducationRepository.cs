using DigitalCV.Data.Domain.Models;
using System.Collections.Generic;

namespace DigitalCV.Data.Interfaces
{
    public interface IEducationRepository
    {
        List<Education> GetEducations();

        Education GetEducationFromID(int ID);

        void CreateEducation(Education model);

        void UpdateEducation(Education model);

        void DeleteEducation(int ID);
    }

}
