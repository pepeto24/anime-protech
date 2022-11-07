using AnimesProtech.Core.Entities;

namespace AnimesProtech.Core.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);
        IQueryable<T> GetAll();
        Task CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task ActivateOrInactivateAsync(Guid id, bool status);
    }
}
