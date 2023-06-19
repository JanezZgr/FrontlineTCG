using FrontlineTCG.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FrontlineTCG;

[DependsOn(
    typeof(FrontlineTCGEntityFrameworkCoreTestModule)
    )]
public class FrontlineTCGDomainTestModule : AbpModule
{

}
