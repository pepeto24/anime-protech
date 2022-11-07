using AnimesProtech.Core.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesProtech.Core.UseCases.Anime
{
    public class ActiveOrInactiveAnimeUseCase : BaseUseCase<IAnimeRepository>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ActiveOrInactiveAnimeUseCase(IAnimeRepository repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Execute(Guid id, bool status)
        {
            _unitOfWork.BeginWork();

            try
            {

                var anime = await _repository.GetByIdAsync(id)
                ?? throw new Exception("Anime não encontrado!");

                await _repository.ActivateOrInactivateAsync(id, status);

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
