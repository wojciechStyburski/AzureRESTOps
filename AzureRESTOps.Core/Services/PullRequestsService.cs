namespace AzureRESTOps.Core.Services;

public class PullRequestsService 
(
    IOptions<AzureDevopsSettings> azureDevopsSettings,
    AzureDevopsHelper azureDevopsHelper
) : IPullRequestsService
{
    private readonly AzureDevopsSettings _azureDevopsSettings = azureDevopsSettings.Value;
    private AuthenticationHeaderValue _token;

    public async Task<PullRequestResponse> GetAsync()
    {
        _token = azureDevopsHelper.CreateAuthorizationToken();
        var url = BuildUrl();
        
        var response = await url.WithHeader("Authorization", _token).GetStringAsync();
        var pullRequests = JsonConvert.DeserializeObject<PullRequestResponse>(response);

        return pullRequests;
    }
    
    private string BuildUrl()
    {
        return $"{_azureDevopsSettings.BaseUrl}/"
            .AppendPathSegments
            (
                _azureDevopsSettings.Organization,
                _azureDevopsSettings.Project, 
                "_apis", 
                "git",
                "pullrequests"
            ).SetQueryParam("api-version", _azureDevopsSettings.ApiVersion);
    }
}