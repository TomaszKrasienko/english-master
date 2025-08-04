using english_master.DAL;
using english_master.Graph.Types;
using english_master.Queries;

namespace english_master.Graph;

internal static class GraphQlConfigurationServicesExtensions
{
    internal static IServiceCollection AddGraphQl(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddQueryType<WordsQuery>()
            .AddType<WordType>()
            .AddFiltering()
            .AddSorting()
            .AddProjections()
            .RegisterDbContextFactory<EnglishMasterDbContext>();
        
        return services;
    } 
}