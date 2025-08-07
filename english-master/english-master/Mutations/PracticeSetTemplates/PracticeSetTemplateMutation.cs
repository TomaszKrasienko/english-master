using english_master.DAL;
using english_master.Models;
using english_master.Mutations.PracticeSetTemplates.Types;
using Microsoft.EntityFrameworkCore;

namespace english_master.Mutations.PracticeSetTemplates;

public class PracticeSetTemplateMutation
{
    public async Task<PracticeSetTemplate> CreatePracticeSetTemplate(
        CreatePracticeSetTemplateInput input,
        [Service] EnglishMasterDbContext context,
        CancellationToken ct)
    {
        var words = await context
            .Words
            .Where(x => input.Words.Contains(x.Id))
            .ToListAsync(ct);
        
        var template = PracticeSetTemplate.Create(
            input.Name,
            words);
        
        context.PracticeSetTemplates.Add(template);
        await context.SaveChangesAsync(ct);
        
        return template;
    }
}