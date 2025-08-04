using english_master.DAL;
using english_master.Models;
using Microsoft.EntityFrameworkCore;

namespace english_master.Queries;

public sealed class WordsQuery
{
    [UseFiltering]
    [UseSorting]
    public IQueryable<Word> GetWords([Service] EnglishMasterDbContext context)
        => context
            .Words
            .Include(x => x.Topic)
            .Include(x => x.Sets);

    [UseFirstOrDefault]
    public IQueryable<Word> GetWordById([Service] EnglishMasterDbContext context, Guid id)
        => context
            .Words
            .Include(x => x.Topic)
            .Include(x => x.Sets)
            .Where(w => w.Id == id);
}