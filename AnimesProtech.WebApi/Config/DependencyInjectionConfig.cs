
using AnimesProtech.Core.Dtos;
using AnimesProtech.Core.Repositories;
using AnimesProtech.Core.UseCases;
using AnimesProtech.Core.UseCases.Anime;
using AnimesProtech.Core.Validator;
using AnimesProtech.Core.Validator.Anime;
using AnimesProtech.Infra.Repositories;
using FluentValidation;

namespace AnimesProtech.WebApi.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services, ConfigurationManager configuration)
        {
            
            services.AddTransient<IAnimeRepository, AnimeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AutoMapper.IMapper, AutoMapper.Mapper>();
            services.AddScoped<CreateAnimeUseCase, CreateAnimeUseCase>();
            services.AddScoped<GetAllAnimeByFilterUseCase, GetAllAnimeByFilterUseCase>();
            services.AddScoped<ActiveOrInactiveAnimeUseCase, ActiveOrInactiveAnimeUseCase>();
            services.AddScoped<UpdateAnimeUseCase, UpdateAnimeUseCase>();
            services.AddTransient<IValidator<AnimeWriteDto>, AnimeRegisterValidator>();
            return services;
        }
    }
}
