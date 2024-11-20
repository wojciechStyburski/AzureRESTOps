namespace AzureRESTOps.Client;

internal class App
(
    ClipboardService clipboardService,
    IQueryHandler<GetWorkitemsQuery, ConsoleTable> getWorkitemsQuery
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
                    <GetWorkitemsQuery>(args)
                    .WithParsedAsync(async parsed =>
                    {
                        switch (parsed)
                        {
                            case GetWorkitemsQuery:
                                tableResult = await getWorkitemsQuery.HandleAsync(parsed as GetWorkitemsQuery);
                                break;
                            default:
                                Console.WriteLine("No action allowed, try again.");
                                break;
                        }
                    });
                    
            tableResult?.Configure(o => o.NumberAlignment = Alignment.Right).Write(Format.Minimal);
            
            if (args.Any(arg => arg.Contains(Helpers.WorkitemsCommandName, StringComparison.InvariantCultureIgnoreCase)))
                await clipboardService.WriteWorkitemDetailsToClipboardAsync(tableResult);
        }
        catch (Exception exception)
        {
            var errorDetails = ErrorHandler.HandleException(exception);
            Console.WriteLine($"Sorry, we have trouble: {errorDetails.Code}, details: [{errorDetails.Reason}]");
        }
    }
}