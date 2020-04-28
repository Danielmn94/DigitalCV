using DigitalCV.Data.Domain;
using DigitalCV.Data.Domain.Interfaces;
using DigitalCV.Data.Helpers;
using DigitalCV.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DigitalCV.Data.Repositories
{
    public class GenericRepositoy<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DigitalCVContext _context;
        private DbSet<T> _entities;
        private readonly Logger _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GenericRepositoy(DigitalCVContext context, Logger logger, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _entities = context.Set<T>();
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Create(T entity, [CallerMemberName] string callerMemberName = "")
        {
            try
            {
                _entities.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogErrorWithUser(GetType().Name, "", e.Message, e.InnerException == null ? "" : e.InnerException.Message,
                    _httpContextAccessor.HttpContext.User.Identity.Name, callerMemberName);
            }
        }

        public void Delete(int id, [CallerMemberName] string callerMemberName = "")
        {
            try
            {
                var entity = _entities.SingleOrDefault(e => e.Id == id);

                _entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogErrorWithUser(GetType().Name, "ID: " + id,  e.Message,  e.InnerException == null ? "" : e.InnerException.Message,
                    _httpContextAccessor.HttpContext.User.Identity.Name, callerMemberName);
            }
        }

        public IEnumerable<T> GetAll([CallerMemberName] string callerMemberName = "")
        {
            try
            {
                return _entities.AsEnumerable();
            }
            catch (Exception e)
            {
                _logger.LogErrorWithUser(GetType().Name,"", e.Message,  e.InnerException == null ? "" : e.InnerException.Message,
                    _httpContextAccessor.HttpContext.User.Identity.Name, callerMemberName);

                return null;
            }
        }

        public DateTime GetAdded(int id, [CallerMemberName] string callerMemberName = "")
        {
            try
            {
                return _entities.Where(s => s.Id == id).Select(s => s.Added).FirstOrDefault();
            }
            catch (Exception e)
            {
                _logger.LogErrorWithUser(GetType().Name, "ID: " + id, e.Message,  e.InnerException == null ? "" : e.InnerException.Message, 
                    _httpContextAccessor.HttpContext.User.Identity.Name, callerMemberName);

                return DateTime.MinValue;
            }
        }

        public T GetById(int id, [CallerMemberName] string callerMemberName = "")
        {
            try
            {
                return _entities.SingleOrDefault(s => s.Id == id);
            }
            catch (Exception e)
            {
                _logger.LogErrorWithUser(GetType().Name, "ID: " + id, e.Message,  e.InnerException == null ? "" : e.InnerException.Message,
                    _httpContextAccessor.HttpContext.User.Identity.Name, callerMemberName);

                return null;
            }
        }

        public void Update(T entity, [CallerMemberName] string callerMemberName = "")
        {
            try
            {
                _entities.Update(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogErrorWithUser(GetType().Name, "Entity: " + entity.Id, e.Message,  e.InnerException == null ? "" : e.InnerException.Message,
                    _httpContextAccessor.HttpContext.User.Identity.Name, callerMemberName);
            }
        }
    }
}
