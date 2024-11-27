namespace AzureRESTOps.Shared.Models;

public class WorkitemsDetailsDto
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string State { get; set; }
    public string Title { get; set; }
    public double CompletedWork { get; set; }
}