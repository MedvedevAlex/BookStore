using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace Model
{
    public class BookContextFactory : IDesignTimeDbContextFactory<BookContext>
    {
        public BookContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var optionsBuilder = new DbContextOptionsBuilder<BookContext>();

            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .Build();
            var connectionString = config.GetConnectionString("BookStoreConnection");
            optionsBuilder.UseSqlServer(args.Length == 0 ? connectionString : args[0], b => b.MigrationsAssembly("Model"));

            return new BookContext(optionsBuilder.Options);
        }
    }
}
