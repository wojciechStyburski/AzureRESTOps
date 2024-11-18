namespace AzureRESTOps.Client.AppConfiguration;

public static class Extensions
{
    public static IConfigurationBuilder AddConfiguration(this IConfigurationBuilder builder)
    {
        builder
            .SetBasePath(AppDomain.CurrentDomain.SetupInformation.ApplicationBase)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        return builder;
    }
}