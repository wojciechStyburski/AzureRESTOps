namespace AzureRESTOps.Client.Exceptions;

internal class ErrorHandler
{
    public static Error HandleException(Exception exception)
    {
        var errorDetails = exception switch
        {
            CustomException =>
                new Error(exception.GetType().Name.Underscore().Replace("_exception", string.Empty), exception.Message),
            _ => new Error("Application error", exception.Message)

        };

        return errorDetails;
    }
}