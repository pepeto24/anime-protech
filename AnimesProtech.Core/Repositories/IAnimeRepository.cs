using AnimesProtech.Core.Dtos;
using AnimesProtech.Core.Dtos.Page;
using AnimesProtech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesProtech.Core.Repositories
{
    public interface IAnimeRepository : IBaseRepository<Anime>
    {
        Task<PageDto<Anime>> GetByFilterAsync(AnimeFilterDto filter);
        Task<bool> IsNomeInUse(string nome, Guid? Id = null);
    }
}
