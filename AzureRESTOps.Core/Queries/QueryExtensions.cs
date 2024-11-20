namespace AzureRESTOps.Core.Queries;

public static class QueryExtensions
{
    public static IServiceCollection AddQueries(this IServiceCollection services)
    {
        var assembly = typeof(IQuery<>).Assembly;
        
        services
            .Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

        return services;
    }
}