using AutoMapper;

namespace AnimesProtech.Core.UseCases
{
    public abstract class BaseUseCase<IR>
    {
        public readonly IR _repository;
        public readonly IMapper _mapper;

        public BaseUseCase(IR repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
