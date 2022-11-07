using AnimesProtech.Core.Dtos;
using AnimesProtech.Core.Dtos.Page;
using AnimesProtech.Core.Entities;
using AnimesProtech.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AnimesProtech.Infra.Repositories
{
    public class AnimeRepository : BaseRepository<Anime>, IAnimeRepository
    {
        public AnimeRepository(BaseContext context) : base(context)
        {
        }

        public async Task<PageDto<Anime>> GetByFilterAsync(AnimeFilterDto filter)
        {
            var query = _dbEntity
                .WhereIf(!string.IsNullOrEmpty(filter.Nome), x => x.Nome.ToUpper().Contains(filter.Nome.ToUpper()))
                .WhereIf(!string.IsNullOrEmpty(filter.Resumo), x => x.Resumo.ToUpper().Contains(filter.Resumo.ToUpper()))
                .WhereIf(!string.IsNullOrEmpty(filter.Diretor), x => x.Diretor.ToUpper().Contains(filter.Diretor.ToUpper()))
                .Where(x => x.Ativo);

            return await Paginate(query, filter);
        }

        public Task<bool> IsNomeInUse(string nome, Guid? Id)
        {
            return _dbEntity
                .AsNoTracking()
                .WhereIf(Id.HasValue, x => x.Id != Id!.Value)
                .WhereIf(!string.IsNullOrEmpty(nome), x => x.Nome.ToUpper() == nome.Trim().ToUpper())
                .AnyAsync();
        }
    }
}
