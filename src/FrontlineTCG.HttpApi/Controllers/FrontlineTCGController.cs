using FrontlineTCG.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FrontlineTCG.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class FrontlineTCGController : AbpControllerBase
{
    protected FrontlineTCGController()
    {
        LocalizationResource = typeof(FrontlineTCGResource);
    }
}
