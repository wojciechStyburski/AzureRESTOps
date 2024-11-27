namespace AzureRESTOps.Shared.Models;

public class PullRequestResponse
{
    public List<PullRequest> Value { get; set; }
}

public class PullRequest
{
    public Repository Repository { get; set; }
    public int PullRequestId { get; set; }
    public string Status { get; set; }
    public DateTime CreationDate { get; set; }
    public CreatedBy CreatedBy { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Reviewers> Reviewers { get; set; }    
}

public class Repository
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}

public class CreatedBy
{
    public string DisplayName { get; set; }
    public string UniqueName { get; set; }
}

public class Reviewers
{
    public string DisplayName { get; set; }
}