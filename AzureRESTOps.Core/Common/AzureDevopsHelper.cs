namespace AzureRESTOps.Core.Common;

public class AzureDevopsHelper(IOptions<AzureDevopsSettings> azureDevopsSettings)
{
    private readonly AzureDevopsSettings _azureDevopsSettings = azureDevopsSettings.Value;
    
    public AuthenticationHeaderValue CreateAuthorizationToken()
    {
        var token = new AuthenticationHeaderValue
        (
            "Basic",
            Convert.ToBase64String(Encoding.ASCII.GetBytes($":{_azureDevopsSettings.Token}"))
        );
        return token;
    }
}