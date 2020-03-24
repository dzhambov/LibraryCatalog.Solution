using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LibraryCatalog.Models
{
  public class LibraryCatalogContextFactory : IDesignTimeDbContextFactory<LibraryCatalogContext>
  {

    LibraryCatalogContext IDesignTimeDbContextFactory<LibraryCatalogContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<LibraryCatalogContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new LibraryCatalogContext(builder.Options);
    }
  }
}