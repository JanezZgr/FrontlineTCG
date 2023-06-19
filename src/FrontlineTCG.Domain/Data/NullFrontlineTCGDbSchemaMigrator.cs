using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace FrontlineTCG.Data;

/* This is used if database provider does't define
 * IFrontlineTCGDbSchemaMigrator implementation.
 */
public class NullFrontlineTCGDbSchemaMigrator : IFrontlineTCGDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
