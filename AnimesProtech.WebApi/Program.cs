using AnimesProtech.Core.AutoMapper;
using AnimesProtech.Core.Validator;
using AnimesProtech.Core.Validator.Anime;
using AnimesProtech.Infra;
using AnimesProtech.WebApi.Config;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddValidatorsFromAssemblyContaining<typeof(AnimeRegisterValidator)>();

//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(System.Reflection.Assembly.GetAssembly(typeof(AnimeMapper)));
builder.Services.AddDependencyInjectionConfig(builder.Configuration);
builder.Services.AddDbContext<BaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
