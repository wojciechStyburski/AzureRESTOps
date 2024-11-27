namespace AzureRESTOps.Core.Services;

public class WorkitemsService
(
    IOptions<AzureDevopsSettings> azureDevopsSettings,
    AzureDevopsHelper azureDevopsHelper
) : IWorkitemsService
{
    private readonly AzureDevopsSettings _azureDevopsSettings = azureDevopsSettings.Value;
    private string _url = string.Empty;
    private AuthenticationHeaderValue _token;
    
    public async Task<WorkitemsDetailsResponse> GetAsync(GetWorkitemsQuery query)
    {
        _token = azureDevopsHelper.CreateAuthorizationToken();
        
        var workitems = await GetWorkitemsFromQuery();
        var workitemsDetails = await GetWorkitemsDetails(workitems);

        return workitemsDetails;
    }

    private async Task<WorkitemsResponse> GetWorkitemsFromQuery()
    {
        CleanUrl();

        _url = _url
            .AppendPathSegments("wiql", _azureDevopsSettings.QueryId)
            .SetQueryParam("api-version", _azureDevopsSettings.ApiVersion);

        var response = await _url.WithHeader("Authorization", _token).GetStringAsync();
        var workitems = JsonConvert.DeserializeObject<WorkitemsResponse>(response);

        return workitems;
    }

    private async Task<WorkitemsDetailsResponse> GetWorkitemsDetails(WorkitemsResponse workitemsResponse)
    {
        CleanUrl();

        var workitems = workitemsResponse.Workitems.ToList();
        var workitemIds = string.Join(",", workitems.Select(x => x.Id.ToString()));
        _url = _url
            .AppendPathSegments("workitems")
            .SetQueryParam("ids", workitemIds)
            .SetQueryParam("api-version", _azureDevopsSettings.ApiVersion);

        var response = await _url.WithHeader("Authorization", _token).GetStringAsync();
        var workitemsDetails = JsonConvert.DeserializeObject<WorkitemsDetailsResponse>(response);

        return workitemsDetails;
    }
    private void CleanUrl()
    {
        _url = $"{_azureDevopsSettings.BaseUrl}/"
            .AppendPathSegments
            (
                _azureDevopsSettings.Organization,
                _azureDevopsSettings.Project, 
                "_apis", 
                "wit"
            );
    }
}