using API.Filters;
using API.Infrastructure.WebBook;
using API.Infrastructure.WebPainter;
using API.Infrastructure.WebPublisher;
using InterfaceDB.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceDb.BookRepos;
using ServiceDb.PainterRepos;
using ServiceDb.PublisherRepos;

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
                .AddScoped<IWebBookScenario, WebBookScenario>()
                .AddScoped<IBookRepository, BookRepository>()
                .AddScoped<IWebPainterScenario, WebPainterScenario>()
                .AddScoped<IPainterRepository, PainterRepository>()
                .AddScoped<IWebPublisherScenario, WebPublisherScenario>()
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
