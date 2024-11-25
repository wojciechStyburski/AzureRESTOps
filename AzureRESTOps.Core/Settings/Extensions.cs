namespace AzureRESTOps.Core.Settings;

public static class Extensions
{
    private const string AzureDevopsSettingSection = "AzureDevopsSettings";
    public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AzureDevopsSettings>
        (
            o => configuration.GetSection(AzureDevopsSettingSection).Bind(o)
        ).AddOptionsWithValidateOnStart<AzureDevopsSettings, AzureDevopsSettingValidator>();
        
        return services;
    }
}