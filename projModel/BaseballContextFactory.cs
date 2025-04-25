using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace projModel
{
    public class BaseballContextFactory : IDesignTimeDbContextFactory<BaseballContext>
    {
        public BaseballContext CreateDbContext(string[] args)
        {
            // Start with the current directory (which is the projModel folder)
            string currentDir = Directory.GetCurrentDirectory();

            // Check if the appsettings.json is in the current directory
            string jsonPath = Path.Combine(currentDir, "appsettings.json");

            if (!File.Exists(jsonPath))
            {
                // Adjust the path to point to your main project's directory. For example,
                // if your solution folder contains two sub-folders "projModel" and "584_bb_proj" (the main project),
                // you might go up two levels and then into the main project folder:
                currentDir = Path.GetFullPath(Path.Combine(currentDir, "..", "584_bb_proj"));
                jsonPath = Path.Combine(currentDir, "appsettings.json");
            }

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(currentDir)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<BaseballContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new BaseballContext(optionsBuilder.Options);
        }
    }
}
