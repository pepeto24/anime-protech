using AnimesProtech.Core.Dtos.Page;
using AnimesProtech.Core.Entities;
using AnimesProtech.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AnimesProtech.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly BaseContext _context;
        protected readonly DbSet<T> _dbEntity;

        public BaseRepository(BaseContext context)
        {
            _context = context;
            _dbEntity = context.Set<T>();
        }

        public virtual T GetById(Guid id) => _dbEntity.AsNoTracking().FirstOrDefault(x => x.Id.Equals(id));
        public Task<T> GetByIdAsync(Guid id) => _dbEntity.AsNoTracking().FirstOrDefaultAsync(x => x.Id.Equals(id));
        public virtual IQueryable<T> GetAll() => _dbEntity.AsNoTracking().OrderByDescending(c => c.CriadoEm);

        public async Task ActivateOrInactivateAsync(Guid id, bool status)
        {
            DateTime? dataInativacao = null;
            if (!status) dataInativacao = DateTime.Now;

            T entity = GetById(id);
            entity.DataInativacao = dataInativacao;
            entity.AlteradoEm = DateTime.Now;
            entity.Ativo = status;
            _dbEntity.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(T entity)
        {
            entity.Id = entity.Id.Equals(Guid.Empty) ? Guid.NewGuid() : entity.Id;
            entity.CriadoEm = DateTime.Now;
            entity.Ativo = true;
            _dbEntity.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbEntity.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        protected async Task<PageDto<T>> Paginate(IQueryable<T> query, PageFilterDto filter)
        {
            var totalItems = query.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / (double)filter.ItemsPerPage);
            var result = await query
                .Skip((filter.Page - 1) * filter.ItemsPerPage)
                .Take(filter.ItemsPerPage)
                .ToListAsync();

            return new PageDto<T>
            {
                CurrentPage = filter.Page,
                ItemsPerPage = filter.ItemsPerPage,
                TotalPages = totalPages,
                OrderBy = filter.OrderBy,
                Content = result,
                TotalItems = totalItems
            };
        }



    }
}
