using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Model.Handlers;
using Service;
using System;
using System.Reflection;
using ViewModel.Interfaces.Handlers;

namespace Test
{
    public static class ConfigDI
    {
        public static IServiceProvider GetServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();
            InsertServices(services);
            return services.BuildServiceProvider();
        }
        public static IServiceProvider GetServiceProvider(IServiceCollection services)
        {
            InsertServices(services);
            return services.BuildServiceProvider();
        }
        public static IServiceCollection InsertServices(IServiceCollection services)
        {
            services.AddTransient<IMapper, Mapper>(ctx => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(Assembly.GetAssembly(typeof(MappingProfile)));
            })));
            services.AddScoped<IBookHandler, BookHandler>();
            return services;
        }
    }
}
