using DigitalCV.Data.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Data.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll([CallerMemberName] string callerMemberName = "");

        DateTime GetAdded(int id, [CallerMemberName] string callerMemberName = "");

        T GetById(int id, [CallerMemberName] string callerMemberName = "");

        void Create(T entity, [CallerMemberName] string callerMemberName = "");

        void Update(T entity, [CallerMemberName] string callerMemberName = "");

        void Delete(int id, [CallerMemberName] string callerMemberName = "");
    }
}
