using AnimesProtech.Core.Dtos;
using AnimesProtech.Core.Repositories;
using AutoMapper;
using AnimeEntityModel = AnimesProtech.Core.Entities.Anime;

namespace AnimesProtech.Core.UseCases.Anime
{
    public class CreateAnimeUseCase : BaseUseCase<IAnimeRepository>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAnimeUseCase(IAnimeRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, mapper)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> Execute(AnimeWriteDto dto)
        {
            _unitOfWork.BeginWork();
            try
            {

                /*if (await _repository.IsNomeInUse(dto.Nome))
                {
                    throw new Exception("Já existe registro com este nome em uso!");
                }*/

                var anime = _mapper.Map<AnimeEntityModel>(dto);

                await _repository.CreateAsync(anime);

                _unitOfWork.Commit();

                return true;

            }catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }
            
        }

    }
}
