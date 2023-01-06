using Application.Common.Interfaces.Repositories;
using Domain.Common;
using Infrastructure.Persistence;
using System.Linq.Expressions;

namespace CMS.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseAuditableEntity
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
