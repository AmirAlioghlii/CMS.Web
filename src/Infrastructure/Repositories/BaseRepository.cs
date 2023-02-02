using Application.Common.Interfaces.Repositories;
using Domain.Common;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CMS.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseAuditableEntity
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> entities;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public void Add(T entity)
        {
            entities.Add(entity);
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await entities.FirstOrDefaultAsync(a => a.Id == id);
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
