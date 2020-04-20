using DigitalCV.Data.Domain.Models;
using System.Collections.Generic;

namespace DigitalCV.Data.Interfaces
{
    public interface IComputerTechnologyRepository
    {
        List<ComputerTechnology> GetAllComputerTechnologies();
    }
}
