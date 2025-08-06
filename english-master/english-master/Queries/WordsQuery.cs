using english_master.DAL;
using english_master.Models;
using Microsoft.EntityFrameworkCore;

namespace english_master.Queries;

[ExtendObjectType(typeof(EnglishMasterQuery))]
public class WordsQuery
{
    [UseFiltering]
    [UseSorting]
    public IQueryable<Word> GetWords([Service] EnglishMasterDbContext context)
        => context
            .Words
            .Include(x => x.Topic)
            .Include(x => x.Sets);

    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Word> GetWordsPaginated([Service] EnglishMasterDbContext context)
    {
        var query = context
            .Words
            .Include(x => x.Topic)
            .Include(x => x.Sets)
            .AsNoTracking();

        query = query.OrderBy(x => x.Term);
        
        return query;
    }

    [UseFirstOrDefault]
    public IQueryable<Word> GetWordById([Service] EnglishMasterDbContext context, Guid id)
        => context
            .Words
            .Include(x => x.Topic)
            .Include(x => x.Sets)
            .Where(w => w.Id == id);
}