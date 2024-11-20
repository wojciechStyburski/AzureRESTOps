using ClipboardService = AzureRESTOps.Core.Services.ClipboardService;

namespace AzureRESTOps.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.InjectClipboard();
        services.AddSettings(configuration);
        services.AddQueries();
        services.AddScoped<IWorkitemsService, WorkitemsService>();
        services.AddSingleton<ClipboardService>();

        
        return services;
    }
}