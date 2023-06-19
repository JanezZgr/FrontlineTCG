using Volo.Abp.Modularity;

namespace FrontlineTCG;

[DependsOn(
    typeof(FrontlineTCGApplicationModule),
    typeof(FrontlineTCGDomainTestModule)
    )]
public class FrontlineTCGApplicationTestModule : AbpModule
{

}
