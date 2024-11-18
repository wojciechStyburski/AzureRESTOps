namespace AzureRESTOps.Client;

internal class App
{
    public async Task Run(string[] args)
    {
        Console.WriteLine("AzureDevops REST Operations");

        try
        {
            //Some logic...
        }
        catch (Exception exception)
        {
            var errorDetails = ErrorHandler.HandleException(exception);
            Console.WriteLine($"Sorry, we have trouble: {errorDetails.Code}, details: [{errorDetails.Reason}]");
        }
    }
}