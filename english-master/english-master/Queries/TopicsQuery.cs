using english_master.DAL;
using english_master.Models;
using Microsoft.EntityFrameworkCore;

namespace english_master.Queries;

[ExtendObjectType(typeof(EnglishMasterQuery))]
public class TopicsQuery
{
    [UsePaging] // Musi być przed dolnymi, sprawdź kolejność
    [UseFiltering]
    [UseSorting]
    public IQueryable<Topic> GetTopics([Service] EnglishMasterDbContext context)
        => context
            .Topics
            .Include(x => x.Words);
    
    [UseFirstOrDefault]
    public IQueryable<Topic> GetTopicsById([Service] EnglishMasterDbContext context, Guid id)
        => context
            .Topics
            .Include(x => x.Words)
            .Where(w => w.Id == id);
}