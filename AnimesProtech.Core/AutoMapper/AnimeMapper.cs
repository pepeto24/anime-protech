using AnimesProtech.Core.Dtos;
using AnimesProtech.Core.Dtos.Anime;
using AnimesProtech.Core.Dtos.Page;
using AnimesProtech.Core.Entities;
using AutoMapper;
using AnimeEntityModel = AnimesProtech.Core.Entities.Anime;

namespace AnimesProtech.Core.AutoMapper
{
    public class AnimeMapper : Profile
    {
        public AnimeMapper()
        {
            CreateMap<AnimeEntityModel, AnimeWriteDto>().ReverseMap();

            CreateMap<AnimeEntityModel, AnimeListDto>().ReverseMap();   
            CreateMap<PageDto<AnimeEntityModel>, PageDto<AnimeListDto>>()
                .ForPath(x => x.Content, x => x.MapFrom(src => src.Content))
                .ReverseMap();

            CreateMap<AnimeEntityModel, AnimeReadDto>()
                .ReverseMap();

        }
    }
}
