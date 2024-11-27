using Newtonsoft.Json;

namespace AzureRESTOps.Shared.Models;

public class WorkitemsResponse
{
    [JsonProperty("workItems")]
    public List<Workitem> Workitems { get; set; }
    
    public class Workitem
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}