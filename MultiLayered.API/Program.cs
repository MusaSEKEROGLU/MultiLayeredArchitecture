using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiLayered.API.AutoFacModule;
using MultiLayered.API.Middlewares;
using MultiLayered.API.ValidationFilters;
using MultiLayered.Respository.Contexts;
using MultiLayered.Service.Mapping;
using MultiLayered.Service.Validations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()); //ekledik
//ekledik
builder.Host.ConfigureContainer<ContainerBuilder>(conBuilder =>
conBuilder.RegisterModule(new RepositoryServiceModule()));

builder.Services.AddAutoMapper(typeof(MapProfile));  //ekledik

builder.Services.AddScoped(typeof(NotFountFilter<>)); //ekledik

builder.Services.AddMemoryCache(); //ekledik

#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddControllers(valFilter => valFilter.Filters.Add(new ValidatorFilter())).AddFluentValidation  //ekledik
    (val => val.RegisterValidatorsFromAssemblyContaining<TeamDtoValidator>());

//otomatik gelen FluentValidation'ý kapatma, kendi hata sýnýfýmýzý dönmek için
builder.Services.Configure<ApiBehaviorOptions>(iptal =>
{
    iptal.SuppressModelStateInvalidFilter = true;
});
#pragma warning restore CS0618 // Type or member is obsolete

//ekledik
builder.Services.AddDbContext<AppDbContext>(db =>
{
    db.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),opt =>
    {
        opt.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomException(); //ekledik

app.UseAuthorization();

app.MapControllers();

app.Run();
