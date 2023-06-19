using FrontlineTCG.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FrontlineTCG.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class FrontlineTCGPageModel : AbpPageModel
{
    protected FrontlineTCGPageModel()
    {
        LocalizationResourceType = typeof(FrontlineTCGResource);
    }
}
