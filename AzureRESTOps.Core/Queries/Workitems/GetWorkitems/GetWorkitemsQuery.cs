namespace AzureRESTOps.Core.Queries.Workitems.GetWorkitems;

[Verb(Helpers.WorkitemsCommandName, HelpText = Helpers.WorkitemsCommandHelpText)]
public class GetWorkitemsQuery : IQuery<ConsoleTable>
{
    [Option
    (
        Helpers.WorkitemsSearchPhraseShortcut,
        Helpers.WorkitemsSearchPhraseFullName,
        Required = false,
        HelpText = Helpers.WorkitemsSearchPhraseHelpText
    )]
    public string SearchPhrase { get; set; }
}