using DigitalCV.Data.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Data.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        DateTime GetAdded(int id);

        T GetById(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}
