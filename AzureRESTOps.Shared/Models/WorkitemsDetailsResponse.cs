using Newtonsoft.Json;

namespace AzureRESTOps.Shared.Models;

public class WorkitemsDetailsResponse
{
    public int Count { get; set; }
    public List<WorkitemDetail> Value { get; set; }
        
    public class WorkitemDetail
    {
        public int Id { get; set; }
        public int Rev { get; set; }
        public Fields Fields { get; set; }
        public string Url { get; set; }
    }

    public class Fields
    {
        [JsonProperty("System.WorkItemType")] 
        public string Type { get; set; }
    
        [JsonProperty("System.State")] 
        public string State { get; set; }
    
        [JsonProperty("System.Title")] 
        public string Title { get; set; }
    
        [JsonProperty("Microsoft.VSTS.Scheduling.CompletedWork")] 
        public double CompletedWork { get; set; }
    }
}