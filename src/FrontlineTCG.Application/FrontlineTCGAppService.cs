using System;
using System.Collections.Generic;
using System.Text;
using FrontlineTCG.Localization;
using Volo.Abp.Application.Services;

namespace FrontlineTCG;

/* Inherit your application services from this class.
 */
public abstract class FrontlineTCGAppService : ApplicationService
{
    protected FrontlineTCGAppService()
    {
        LocalizationResource = typeof(FrontlineTCGResource);
    }
}
