using english_master.DAL;
using english_master.Graph.Types;
using english_master.Models;

namespace english_master.Queries;

[ExtendObjectType<EnglishMasterQuery>]
public class PracticeSetTemplateQuery
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<PracticeSetTemplate> GetPracticeSetTemplates([Service] EnglishMasterDbContext context)
        => context
            .PracticeSetTemplates;
}