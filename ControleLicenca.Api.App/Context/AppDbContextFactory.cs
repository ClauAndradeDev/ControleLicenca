using ControleLicenca.Context;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ControleLicenca.Api.App.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args = null)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(config.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Solucoes.Api.App"));

            return new AppDbContext(builder.Options);

        }
    }
}
