using API.Authorization;
using API.Filters;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Model;
using Model.Handlers;
using Service;
using Service.PainterRepos;
using Service.PublisherRepos;
using Service.References;
using Service.Services;
using System;
using System.IO;
using System.Reflection;
using ViewModel.Handlers;
using ViewModel.Interfaces.Handlers;
using ViewModel.Interfaces.Handlers.References;
using ViewModel.Interfaces.Services;
using ViewModel.Interfaces.Services.References;

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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true, // Валидация издателя
                            ValidIssuer = AuthOptions.ISSUER, // Издатель
                            ValidateAudience = true, // Валидация потребителя
                            ValidAudience = AuthOptions.AUDIENCE, // Потребитель
                            ValidateLifetime = true, // Валидация времени существования
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(), // Ключ безапосаности
                            ValidateIssuerSigningKey = true, // Валидация ключа безопасности
                        };
                    });

            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(CustomException));
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(b =>
                   {
                       b.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                   });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Test API",
                    Description = "ASP.NET Core Web API"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            //services.AddMvc(opt =>
            //{
            //    opt.Filters.Add(typeof(ValidatorActionFilter));
            //}).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());
            services
            #region Обработчики данных(Handlers)
                .AddScoped<IBookHandler, BookHandler>()
                .AddScoped<IPainterHandler, PainterHandler>()
                .AddScoped<IPublisherHandler, PublisherHandler>()
                .AddScoped<IInterpreterHandler, InterpreterHandler>()
                .AddScoped<IAuthorHandler, AuthorHandler>()
            #endregion
            #region Бизнес слой(Services)
                .AddScoped<IBookService, BookService>()
                .AddScoped<IPainterService, PainterService>()
                .AddScoped<IPublisherService, PublisherService>()
                .AddScoped<IInterpreterService, InterpreterService>()
                .AddScoped<IAuthorService, AuthorService>()
            #endregion
            #region Справочники (Handlers and Services)
                .AddScoped<ICoverTypeHandler, CoverTypeHandler>()
                .AddScoped<IPainterStyleHandler, PainterStyleHandler>()
                .AddScoped<ICoverTypeService, CoverTypeService>()
                .AddScoped<IPainterStyleService, PainterStyleService>();
            #endregion

            services.AddTransient<IMapper, Mapper>(ctx => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(Assembly.GetAssembly(typeof(MappingProfile)));
            })));

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
            });
        }
    }
}
