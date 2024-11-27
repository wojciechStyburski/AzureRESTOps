namespace AzureRESTOps.Core.Queries.PullRequests.GetPullRequests;

public partial class GetPullRequestsQueryHandler
(
    IPullRequestsService pullRequestsService
)
: IQueryHandler<GetPullRequestsQuery, ConsoleTable>
{
    private const int MaxDescriptionLength = 100;
    private const int PullRequestsDateRange = -30;
    
    public async Task<ConsoleTable> HandleAsync(GetPullRequestsQuery query)
    {
        var pullRequestsResult = await pullRequestsService.GetAsync();
        var pullRequests = pullRequestsResult.Value;
        
        var table = new ConsoleTable("No", "Id", "Title", "Description", "Repository", "Status", "Created by", "Creation date", "Reviewers");
        
        pullRequests = pullRequests
            .Where(x => x.CreationDate.Date >= DateTime.Now.Add(TimeSpan.FromDays(PullRequestsDateRange)).Date)
            .ToList();
        
        if (!string.IsNullOrWhiteSpace(query.RepositoryName))
            pullRequests = pullRequests
                .Where(x => x.Repository.Name.Contains(query.RepositoryName, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

        var pullRequestDetails = pullRequests.Select(x => new PullRequestDetailsDto()
        {
            Id = x.PullRequestId,
            Title = x.Title,
            Description = x.Description,
            RepositoryName = x.Repository.Name,
            Status = x.Status,
            CreatedBy = x.CreatedBy.DisplayName,
            CreatedOn = x.CreationDate,
            Reviewers = string.Join(", ", x.Reviewers.Select(r => r.DisplayName))
        });
        
        var i = 1;
        foreach (var pullRequest in pullRequestDetails)
        {
            var description = string.Empty;

            if (pullRequest.Description is not null)
            {
                description = pullRequest.Description.Length > MaxDescriptionLength
                    ? pullRequest.Description[..MaxDescriptionLength]
                    : pullRequest.Description;
            }

            if (!string.IsNullOrWhiteSpace(description))
                description = MyRegex().Replace(description, "");
            
            table.AddRow
            (
                i,
                pullRequest.Id, 
                pullRequest.Title,
                description, 
                pullRequest.RepositoryName,
                pullRequest.Status,
                pullRequest.CreatedBy,
                pullRequest.CreatedOn,
                pullRequest.Reviewers
            );
            
            i++;
        }

        return table;
    }

    [GeneratedRegex(@"\t|\n|\r")]
    private static partial Regex MyRegex();
}