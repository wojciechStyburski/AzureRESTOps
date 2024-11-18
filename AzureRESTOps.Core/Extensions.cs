using AzureRESTOps.Core.Options;

namespace AzureRESTOps.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSettings(configuration);
        return services;
    }
}