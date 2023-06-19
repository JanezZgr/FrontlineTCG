using System.Threading.Tasks;

namespace FrontlineTCG.Data;

public interface IFrontlineTCGDbSchemaMigrator
{
    Task MigrateAsync();
}
