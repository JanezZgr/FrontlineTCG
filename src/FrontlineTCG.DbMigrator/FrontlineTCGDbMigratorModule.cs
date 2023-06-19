using FrontlineTCG.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace FrontlineTCG.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(FrontlineTCGEntityFrameworkCoreModule),
    typeof(FrontlineTCGApplicationContractsModule)
    )]
public class FrontlineTCGDbMigratorModule : AbpModule
{

}
