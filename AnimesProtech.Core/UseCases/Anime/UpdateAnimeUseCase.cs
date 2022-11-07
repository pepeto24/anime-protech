using AnimesProtech.Core.Dtos;
using AnimesProtech.Core.Repositories;
using AutoMapper;
using AnimeModel = AnimesProtech.Core.Entities.Anime;

namespace AnimesProtech.Core.UseCases.Anime
{
    public class UpdateAnimeUseCase : BaseUseCase<IAnimeRepository>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAnimeUseCase(IAnimeRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, mapper)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<bool> Execute(AnimeWriteDto dto)
        {
            _unitOfWork.BeginWork();

            try
            {
                if (await _repository.IsNomeInUse(dto.Nome, dto.Id))
                {
                    throw new Exception("Já existe registro com este nome em uso!");
                }

                var anime = _repository.GetByIdAsync(dto.Id.GetValueOrDefault()) ?? throw new Exception("Anime não encontrado!");

                var animeMapped = _mapper.Map<AnimeModel>(dto);

                await _repository.UpdateAsync(animeMapped);

                _unitOfWork.Commit();

                return true;

            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw ex;
            }

        }

    }
}
