using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FrontlineTCG.Data;
using Volo.Abp.DependencyInjection;

namespace FrontlineTCG.EntityFrameworkCore;

public class EntityFrameworkCoreFrontlineTCGDbSchemaMigrator
    : IFrontlineTCGDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreFrontlineTCGDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the FrontlineTCGDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<FrontlineTCGDbContext>()
            .Database
            .MigrateAsync();
    }
}
