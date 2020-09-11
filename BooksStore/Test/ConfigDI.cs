using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Model.Handlers;
using Service;
using Service.PublisherRepos;
using System;
using System.Reflection;
using Test.ReplaceMethods;
using ViewModel.Interfaces.Handlers;
using ViewModel.Interfaces.Repositories;

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
        public static IServiceCollection InsertServices(IServiceCollection services)
        {
            services.AddTransient<IMapper, Mapper>(ctx => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(Assembly.GetAssembly(typeof(MappingProfile)));
            })));
            services
                .AddScoped<IBookHandler, BookHandler>()
                .AddScoped<IAuthorHandler, AuthorHandler>()
                .AddScoped<IDeliveryHandler, DeliveryHandler>()
                .AddScoped<IInterpreterHandler, InterpreterHandler>()
                .AddScoped<IUserInfoRepository, UserInfoRepositoryReplace>()
                .AddScoped<IOrderHandler, OrderHandler>();
            return services;
        }
    }
}
