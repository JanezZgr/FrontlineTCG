using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FrontlineTCG.Web;

[Dependency(ReplaceServices = true)]
public class FrontlineTCGBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "FrontlineTCG";
}
