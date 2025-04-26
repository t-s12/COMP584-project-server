using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace projModel
{
    public class BaseballContextFactory
        : IDesignTimeDbContextFactory<BaseballContext>
    {
        public BaseballContext CreateDbContext(string[] args)
        {
            var basePath = Path.GetFullPath(
                Path.Combine(Directory.GetCurrentDirectory(), "..", "584_bb_proj"));

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                      ?? "Development";

            var config = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<BaseballContext>();
            optionsBuilder.UseSqlServer(
                config.GetConnectionString("DefaultConnection")
            );

            return new BaseballContext(optionsBuilder.Options);
        }
    }
}
