using System.Linq.Expressions;
using Domain.Common;

namespace Application.Common.Interfaces.Repositories;

public interface IBaseRepository<T> where T : BaseAuditableEntity
{
    IEnumerable<T> GetAll();

    Task<T> GetByIdAsync(long id);

    void Add(T entity);

    void Delete(T entity);

    void Update(T entity);

    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
}