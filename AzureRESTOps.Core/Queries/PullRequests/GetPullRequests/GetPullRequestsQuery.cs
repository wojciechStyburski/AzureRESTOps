namespace AzureRESTOps.Core.Queries.PullRequests.GetPullRequests;

[Verb(Helpers.PullRequestsCommandName, HelpText = Helpers.PullRequestsCommandHelpText)]
public class GetPullRequestsQuery : IQuery<ConsoleTable>
{
    [Option
    (
        Helpers.PullRequestsRepositoryShortcut,
        Helpers.PullRequestsRepositoryFullName,
        Required = false,
        HelpText = Helpers.PullRequestsRepositoryHelpText
    )]
    public string RepositoryName { get; set; }
}