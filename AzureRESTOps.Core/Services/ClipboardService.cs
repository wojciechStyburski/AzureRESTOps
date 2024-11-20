namespace AzureRESTOps.Core.Services;

public class ClipboardService(IClipboard clipboard)
{
    public async Task WriteWorkitemDetailsToClipboardAsync(ConsoleTable table)
    {
        Console.Write("Select workitem by On: ");
        var workitemLp = Console.ReadLine();
        string workitemId = string.Empty;
        foreach (var row in table.Rows)
        {
            if (row[0].ToString() != workitemLp) 
                continue;
            
            workitemId = row[1].ToString();
            break;
        }

        if (!string.IsNullOrWhiteSpace(workitemId))
            await clipboard.SetTextAsync(workitemId);
        else
            throw new Exception("Invalid ON number from workitem list.");
    } 
}