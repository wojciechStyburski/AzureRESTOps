namespace AzureRESTOps.Shared.Common;

public class Helpers
{
    public const string WorkitemsCommandName = "workitems";
    public const string WorkitemsCommandHelpText = "Get workitems from query";
    
    public const string PullRequestsCommandName = "pullrequests";
    public const string PullRequestsCommandHelpText = "Get pull requests";
    
    public const char WorkitemsSearchPhraseShortcut = 'f';
    public const string WorkitemsSearchPhraseFullName = "Workitem title";
    public const string WorkitemsSearchPhraseHelpText = "Specify phrase to search by workitem title";
    
    public const char PullRequestsRepositoryShortcut = 'r';
    public const string PullRequestsRepositoryFullName = "Repository name";
    public const string PullRequestsRepositoryHelpText = "Specify repository name to search pull requests";
}