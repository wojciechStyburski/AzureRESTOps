namespace AzureRESTOps.Core.Services;

public interface IWorkitemsService
{
    Task<WorkitemsDetailsResponse> GetAsync(GetWorkitemsQuery query);
}