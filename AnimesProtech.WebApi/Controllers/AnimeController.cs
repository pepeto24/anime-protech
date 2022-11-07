using AnimesProtech.Core.Dtos;
using AnimesProtech.Core.Dtos.Anime;
using AnimesProtech.Core.Dtos.Page;
using AnimesProtech.Core.UseCases.Anime;
using Microsoft.AspNetCore.Mvc;

namespace AnimesProtech.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AnimeController : ControllerBase
    {
        public AnimeController() { }

        [HttpGet]
        public async Task<ActionResult<PageDto<AnimeListDto>>> GetAllAnime([FromQuery] AnimeFilterDto filter, [FromServices] GetAllAnimeByFilterUseCase useCase)
        {
            return Ok(await useCase.Execute(filter));
        }

        [HttpPost]
        public async Task<ActionResult> CreateAnime([FromBody] AnimeWriteDto dto, [FromServices] CreateAnimeUseCase useCase)
        {
            return Ok(await useCase.Execute(dto));
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAnime([FromBody] AnimeWriteDto dto, [FromServices] UpdateAnimeUseCase useCase)
        {
            return Ok(await useCase.Execute(dto));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> InactivateActivate(Guid id, [FromBody] bool status, [FromServices] ActiveOrInactiveAnimeUseCase useCase)
        {
            return Ok(await useCase.Execute(id, status));
        }
    }
}
