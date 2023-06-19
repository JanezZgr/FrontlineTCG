using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FrontlineTCG.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class FrontlineTCGDbContextFactory : IDesignTimeDbContextFactory<FrontlineTCGDbContext>
{
    public FrontlineTCGDbContext CreateDbContext(string[] args)
    {
        FrontlineTCGEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<FrontlineTCGDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new FrontlineTCGDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../FrontlineTCG.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
