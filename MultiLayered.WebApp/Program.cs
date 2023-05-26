using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using MultiLayered.Respository.Contexts;
using MultiLayered.Service.Mapping;
using MultiLayered.Service.Validations;
using MultiLayered.WebApp.AutoFacModule;
using MultiLayered.WebApp.Exceptions;
using MultiLayered.WebApp.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddControllersWithViews().AddFluentValidation  //ekledik
    (val => val.RegisterValidatorsFromAssemblyContaining<TeamDtoValidator>()); ;
#pragma warning restore CS0618 // Type or member is obsolete

builder.Services.AddDbContext<AppDbContext>(db =>
{
    db.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), opt =>
    {
        opt.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);
    });
});


//ekledik
builder.Services.AddHttpClient<TeamApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["BaseURL"]);
});


//ekledik
builder.Services.AddHttpClient<CountryApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["BaseURL"]);
});


builder.Services.AddScoped(typeof(NotFoundFilter<>)); //ekledik


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()); //ekledik
//ekledik
builder.Host.ConfigureContainer<ContainerBuilder>(conBuilder =>
conBuilder.RegisterModule(new RepositoryServiceModule()));

builder.Services.AddAutoMapper(typeof(MapProfile));  //ekledik

var app = builder.Build();

app.UseExceptionHandler("/Home/Error");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");  //dýþarýya taþýyoruz hata sayfasýný göstermesi için => üstte


    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
