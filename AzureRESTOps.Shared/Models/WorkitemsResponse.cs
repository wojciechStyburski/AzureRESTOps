namespace AzureRESTOps.Shared.Models;

public class WorkitemsResponse
{
    public List<Workitem> Workitems { get; set; }
    
    public class Workitem
    {
        public string Id { get; set; }
        public string Url { get; set; }
    }
}