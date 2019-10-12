using API.EntityService;
using API.EntityService.PainterRepos;
using API.EntityService.PublisherRepos;
using API.Filters;
using DBLayerAPI;
using DBLayerAPI.PainterLayers;
using DBLayerAPI.PublisherLayers;
using InterfaceDB.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<BookContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BookStoreDatabase")));

            //services.AddMvc(opt =>
            //{
            //    opt.Filters.Add(typeof(ValidatorActionFilter));
            //}).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            services
                .AddScoped<IBookLayer, BookLayer>()
                .AddScoped<IBookRepository, BookRepository>()
                .AddScoped<IPainterLayer, PainterLayer>()
                .AddScoped<IPainterRepository, PainterRepository>()
                .AddScoped<IPublisherLayer, PublisherLayer>()
                .AddScoped<IPublisherRepository, PublisherRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePages();
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
