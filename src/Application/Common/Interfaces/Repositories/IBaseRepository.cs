using System.Linq.Expressions;
using Domain.Common;

namespace Application.Common.Interfaces.Repositories;

public interface IBaseRepository<T> where T : BaseAuditableEntity
{
    Task<IEnumerable<T>> GetAll();
    
    Task<T> GetById(Guid id);
    
    Task<bool> Add(T entity);
    
    Task<bool> Delete(Guid id);
    
    Task<bool> Update(T entity);
    
    Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
}