namespace AzureRESTOps.Core.Queries.Workitems.GetWorkitems;

public class GetWorkItemsQueryHandler
(
    IWorkitemsService workitemsService
) 
: IQueryHandler<GetWorkitemsQuery, ConsoleTable>
{
    public async Task<ConsoleTable> HandleAsync(GetWorkitemsQuery query)
    {
        var workitems = await workitemsService.GetAsync(query);
        var workitemsDetails = workitems.Value.Select(x => new WorkitemsDetailsDTO()
        {
            Id = x.Id,
            Title = x.Fields.Title,
            Type = x.Fields.Type,
            State = x.Fields.State,
            CompletedWork = x.Fields.CompletedWork
        }).ToList();
        
        var table = new ConsoleTable("On", "ID", "State", "Type", "Completed work", "Description");

        if (!string.IsNullOrWhiteSpace(query.SearchPhrase))
            workitemsDetails = workitemsDetails
                .Where(x => x.Title.Contains(query.SearchPhrase, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

        var i = 1;
        foreach (var workitem in workitemsDetails.OrderBy(x => x.Id))
        {
            table.AddRow(i, workitem.Id, workitem.State, workitem.Type, workitem.CompletedWork, workitem.Title);
            i++;
        }
        
        return table;
    }
}