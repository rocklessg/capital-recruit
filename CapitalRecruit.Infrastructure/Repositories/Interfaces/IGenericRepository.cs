using System.Linq.Expressions;
using CapitalRecruit.Domain.Entities;

namespace CapitalRecruit.Infrastructure.Repositories.Interfaces
{    
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity);

        Task DeleteAsync(T entity);

        Task<T> GetAsync(string id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> UpdateAsync(T entity);

        Task<T> GetAsync(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    }
}
