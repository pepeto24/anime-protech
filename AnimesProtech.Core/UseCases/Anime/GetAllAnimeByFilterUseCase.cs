using AnimesProtech.Core.Dtos;
using AnimesProtech.Core.Dtos.Anime;
using AnimesProtech.Core.Dtos.Page;
using AnimesProtech.Core.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesProtech.Core.UseCases.Anime
{
    public class GetAllAnimeByFilterUseCase : BaseUseCase<IAnimeRepository>
    {

        public GetAllAnimeByFilterUseCase(IAnimeRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }

        public async Task<PageDto<AnimeListDto>> Execute(AnimeFilterDto dto)
        {
            try
            {
                var animes = await _repository.GetByFilterAsync(dto);
                return _mapper.Map<PageDto<AnimeListDto>>(animes);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
