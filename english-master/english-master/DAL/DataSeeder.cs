using english_master.Models;
using Microsoft.EntityFrameworkCore;

namespace english_master.DAL;

public class DataSeeder(IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<EnglishMasterDbContext>();

        if (await dbContext.Topics.AnyAsync(cancellationToken)) return;

        var topics = new[]
        {
            Topic.Create(Guid.NewGuid(), "Phrasal Verbs"),
            Topic.Create(Guid.NewGuid(), "Business English"),
            Topic.Create(Guid.NewGuid(), "Idioms"),
        };

        var phrasalVerbs = new List<(string Term, string Translation)>
        {
            ("give up", "poddać się"),
            ("look after", "opiekować się"),
            ("turn on", "włączyć"),
            ("turn off", "wyłączyć"),
            ("pick up", "odebrać (telefon), podnieść"),
            ("break down", "popsuć się"),
            ("get along", "dogadywać się"),
            ("run out of", "wyczerpać się"),
            ("come across", "natknąć się"),
            ("take off", "wystartować (samolot), zdjąć"),
            ("put off", "przełożyć"),
            ("carry on", "kontynuować"),
            ("make up", "wymyślić, pogodzić się"),
            ("look forward to", "nie móc się doczekać"),
            ("check in", "zameldować się"),
            ("check out", "wymeldować się"),
            ("call off", "odwołać"),
            ("figure out", "rozgryźć, zrozumieć"),
            ("take up", "zacząć coś robić"),
            ("set up", "założyć (np. firmę)")
        };

        var businessEnglish = new List<(string Term, string Translation)>
        {
            ("deadline", "termin końcowy"),
            ("stakeholder", "interesariusz"),
            ("ROI", "zwrot z inwestycji"),
            ("revenue", "przychód"),
            ("profit margin", "marża zysku"),
            ("KPI", "kluczowy wskaźnik efektywności"),
            ("turnover", "obrót"),
            ("brainstorm", "burza mózgów"),
            ("synergy", "synergia"),
            ("outsourcing", "zlecanie na zewnątrz"),
            ("merger", "fuzja"),
            ("acquisition", "przejęcie"),
            ("agenda", "porządek obrad"),
            ("pitch", "prezentacja ofertowa"),
            ("cash flow", "przepływ gotówki"),
            ("invoice", "faktura"),
            ("deliverable", "produkt końcowy"),
            ("budget", "budżet"),
            ("benchmark", "punkt odniesienia"),
            ("meeting minutes", "protokół z zebrania")
        };

        var idioms = new List<(string Term, string Translation)>
        {
            ("break the ice", "przełamać lody"),
            ("hit the nail on the head", "trafić w sedno"),
            ("bite the bullet", "zacisnąć zęby"),
            ("a piece of cake", "bułka z masłem"),
            ("let the cat out of the bag", "wygadać się"),
            ("cost an arm and a leg", "kosztować majątek"),
            ("under the weather", "czuć się źle"),
            ("once in a blue moon", "raz na ruski rok"),
            ("speak of the devil", "o wilku mowa"),
            ("kill two birds with one stone", "upiec dwie pieczenie na jednym ogniu"),
            ("the ball is in your court", "teraz twoja kolej"),
            ("burn the midnight oil", "pracować do późna"),
            ("hit the sack", "iść spać"),
            ("by the book", "zgodnie z zasadami"),
            ("in hot water", "w tarapatach"),
            ("keep an eye on", "mieć oko na"),
            ("on the same page", "mieć wspólne zdanie"),
            ("out of the blue", "nagle, niespodziewanie"),
            ("pull someone’s leg", "nabierać kogoś"),
            ("back to the drawing board", "wrócić do punktu wyjścia")
        };

        var words = new List<Word>();

        words.AddRange(phrasalVerbs.Select(p =>
            Word.Create(Guid.NewGuid(), p.Term, p.Translation, topics[0].Id)));

        words.AddRange(businessEnglish.Select(p =>
            Word.Create(Guid.NewGuid(), p.Term, p.Translation, topics[1].Id)));

        words.AddRange(idioms.Select(p =>
            Word.Create(Guid.NewGuid(), p.Term, p.Translation, topics[2].Id)));

        dbContext.AddRange(topics);
        dbContext.AddRange(words);

        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
