using Autofac;
using MultiLayered.Caching;
using MultiLayered.Core.Repositories;
using MultiLayered.Core.Services;
using MultiLayered.Core.UnitOfWorks;
using MultiLayered.Respository.Contexts;
using MultiLayered.Respository.Repositories;
using MultiLayered.Respository.UnitOfWorks;
using MultiLayered.Service.Mapping;
using MultiLayered.Service.Services;
using System.Reflection;
using Module = Autofac.Module;

namespace MultiLayered.API.AutoFacModule
{
    public class RepositoryServiceModule : Module
    {
        // Program cs deki Repository ve Servisleri buraya taşıyoruz
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>))
                .InstancePerLifetimeScope();


            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>))
                .InstancePerLifetimeScope();


            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();


            var apiAssembly = Assembly.GetExecutingAssembly();


            var repositoryAssembly = Assembly.GetAssembly(typeof(AppDbContext));


            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));


            builder.RegisterAssemblyTypes(apiAssembly, repositoryAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(apiAssembly, repositoryAssembly, serviceAssembly)
               .Where(x => x.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerLifetimeScope();

            //Servisleri kullanan MVC uygulaması için Caching den okuyordu kaldırdık

            //builder.RegisterType<TeamServiceAndCaching>().As<ITeamService>();
        }
    }
}
