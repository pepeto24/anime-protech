using AnimesProtech.Core.Dtos;
using AnimesProtech.Core.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesProtech.Core.Validator.Anime
{
    public class AnimeRegisterValidator : AbstractValidator<AnimeWriteDto>
    {
        private readonly IAnimeRepository _repository;

        public AnimeRegisterValidator(IAnimeRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O Nome é obrigatório.")
                .NotNull().WithMessage("O Nome é obrigatório.");

  
        }

       
    }
}
