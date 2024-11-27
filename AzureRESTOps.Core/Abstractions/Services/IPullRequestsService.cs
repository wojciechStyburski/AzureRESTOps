namespace AzureRESTOps.Core.Abstractions.Services;

public interface IPullRequestsService
{
    Task <PullRequestResponse> GetAsync();
}