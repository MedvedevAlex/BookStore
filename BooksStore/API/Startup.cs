﻿using API.Filters;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model.Handlers;
using Model.Models;
using Service;
using Service.BookRepos;
using Service.PainterRepos;
using Service.PublisherRepos;
using System.Reflection;
using ViewModel.Handlers;
using ViewModel.Interfaces.Handlers;
using ViewModel.Interfaces.Services;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(CustomException));
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddDbContext<BookContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BookStoreDatabase")));

            //services.AddMvc(opt =>
            //{
            //    opt.Filters.Add(typeof(ValidatorActionFilter));
            //}).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            services
                .AddScoped<IBookHandler, BookHandler>()
                .AddScoped<IPainterHandler, PainterHandler>()
                .AddScoped<IPublisherHandler, PublisherHandler>()
                .AddScoped<IBookService, BookService>()
                .AddScoped<IPainterService, PainterService>()
                .AddScoped<IPublisherService, PublisherService>();

            services.AddTransient<IMapper, Mapper>(ctx => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(Assembly.GetAssembly(typeof(MappingProfile)));
            })));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStatusCodePages();
            app.UseHsts();

            app.UseHttpsRedirection();
        }
    }
}
