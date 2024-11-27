namespace AzureRESTOps.Core.Abstractions.Services;

public interface IWorkitemsService
{
    Task<WorkitemsDetailsResponse> GetAsync(GetWorkitemsQuery query);
}