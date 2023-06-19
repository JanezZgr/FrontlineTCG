using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace FrontlineTCG;

public class FrontlineTCGWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<FrontlineTCGWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
