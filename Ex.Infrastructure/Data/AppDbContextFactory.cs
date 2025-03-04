using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Ex.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Build configuration for the database connection
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Provide the connection string explicitly or load from config
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=myuser;Password=Arif120829;Database=mydb");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
