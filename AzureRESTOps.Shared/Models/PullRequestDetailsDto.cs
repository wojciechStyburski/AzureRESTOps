namespace AzureRESTOps.Shared.Models;

public class PullRequestDetailsDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string RepositoryName { get; set; }
    public string Status { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string Reviewers { get; set; }
}