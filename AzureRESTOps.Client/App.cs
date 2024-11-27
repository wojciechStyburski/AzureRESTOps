namespace AzureRESTOps.Client;

internal class App
(
    IQueryHandler<GetWorkitemsQuery, ConsoleTable> getWorkitemsQuery,
    IQueryHandler<GetPullRequestsQuery, ConsoleTable> getPullRequestsQuery
)
{
    public async Task Run(string[] args)
    {
        try
        {
            ConsoleTable? tableResult = null;
            
            await Parser
                    .Default
                    .ParseArguments
                    <GetWorkitemsQuery, GetPullRequestsQuery>(args)
                    .WithParsedAsync(async parsed =>
                    {
                        switch (parsed)
                        {
                            case GetWorkitemsQuery query:
                                tableResult = await getWorkitemsQuery.HandleAsync(query);
                                break;
                            case GetPullRequestsQuery query:
                                tableResult = await getPullRequestsQuery.HandleAsync(query);
                                break;
                            default:
                                Console.WriteLine("No action allowed, try again.");
                                break;
                        }
                    });
                    
            tableResult?.Configure(o => o.NumberAlignment = Alignment.Right).Write(Format.Minimal);

        }
        catch (Exception exception)
        {
            var errorDetails = ErrorHandler.HandleException(exception);
            Console.WriteLine($"Sorry, we have trouble: {errorDetails.Code}, details: [{errorDetails.Reason}]");
        }
    }
}