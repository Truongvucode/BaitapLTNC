using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LibraryApp.DAL.Data
{
    public class LibraryDbContextFactory : IDesignTimeDbContextFactory<LibraryDbContext>
    {
        public LibraryDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();

            // Cố gắng tìm file appsettings.json từ UI hoặc thư mục gốc
            string basePath = Directory.GetCurrentDirectory();
            string appSettingsPath = Path.Combine(basePath, "appsettings.json");

            if (!File.Exists(appSettingsPath))
            {
                string uiPath = Path.Combine(basePath, "..", "LibraryApp.UI", "appsettings.json");
                if (File.Exists(uiPath))
                {
                    basePath = Path.GetFullPath(Path.Combine(basePath, "..", "LibraryApp.UI"));
                }
            }

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true);

            var configuration = builder.Build();
            string? connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = "Server=(localdb)\\mssqllocaldb;Database=LibraryDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";
            }

            optionsBuilder.UseSqlServer(connectionString);

            return new LibraryDbContext(optionsBuilder.Options);
        }
    }
}
