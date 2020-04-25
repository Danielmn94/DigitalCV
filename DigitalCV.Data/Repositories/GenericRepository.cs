using DigitalCV.Data.Domain;
using DigitalCV.Data.Domain.Interfaces;
using DigitalCV.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Data.Repositories
{
    public class GenericRepositoy<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DigitalCVContext _context;
        private DbSet<T> _entities;

        public GenericRepositoy(DigitalCVContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public void Create(T entity)
        {
            _entities.Add(entity);
            _context.SaveChanges(); 
        }

        public void Delete(int id)
        {
            var entity = _entities.SingleOrDefault(e => e.Id == id);

            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return _entities.SingleOrDefault(s => s.Id == id);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
        }
    }
}
