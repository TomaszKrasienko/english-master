using english_master.DAL;
using english_master.Graph.Types;
using english_master.Mutations;
using english_master.Mutations.PracticeSetTemplates;
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
            .AddTypeExtension<PracticeSetTemplateQuery>()
            .AddMutationType<EnglishMasterMutation>()
            .AddTypeExtension<PracticeSetTemplateMutation>()
            .AddType<WordType>()
            .AddType<TopicType>()
            .AddType<PracticeSetTemplateType>()
            .AddType<PracticeSetType>()
            .AddType<ResultType>()
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