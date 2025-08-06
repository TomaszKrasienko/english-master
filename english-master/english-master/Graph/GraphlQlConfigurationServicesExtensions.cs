using english_master.DAL;
using english_master.Graph.Types;
using english_master.Queries;
using HotChocolate.Types.Pagination;

namespace english_master.Graph;

internal static class GraphQlConfigurationServicesExtensions
{
    internal static IServiceCollection AddGraphQl(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .AddQueryType<EnglishMasterQuery>()
            .AddTypeExtension<WordsQuery>()
            .AddTypeExtension<TopicsQuery>()
            .AddType<WordType>()
            .AddType<TopicType>()
            .AddFiltering()
            .AddSorting()
            .AddProjections()
            .RegisterDbContextFactory<EnglishMasterDbContext>()
            .ModifyPagingOptions(opt =>
            {
                opt.MaxPageSize = 10;
                opt.DefaultPageSize = 5;
                opt.IncludeTotalCount = true;
            });
        
        return services;
    } 
}