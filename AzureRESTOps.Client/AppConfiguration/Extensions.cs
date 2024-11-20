namespace AzureRESTOps.Client.AppConfiguration;

public static class Extensions
{
    public static IConfigurationBuilder AddConfiguration(this IConfigurationBuilder builder)
    {
        builder
            .SetBasePath(AppDomain.CurrentDomain.SetupInformation.ApplicationBase)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //https://www.youtube.com/watch?v=z7w-aheVrC4
            .AddUserSecrets<Program>();

        return builder;
    }
}