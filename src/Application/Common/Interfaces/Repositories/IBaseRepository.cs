using System.Linq.Expressions;
using Domain.Common;

namespace Application.Common.Interfaces.Repositories;

public interface IBaseRepository<T> where T : BaseAuditableEntity
{
    IEnumerable<T> GetAll();

    T GetById(Guid id);

    void Add(T entity);

    void Delete(Guid id);

    void Update(T entity);

    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
}