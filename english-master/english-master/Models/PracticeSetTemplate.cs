namespace english_master.Models;

public class PracticeSetTemplate
{
    private readonly List<Word> _words = [];
    public int Id { get; }
    public string Name { get; }
    public IReadOnlyCollection<Word> Words => _words.AsReadOnly();

    private PracticeSetTemplate() { }
    
    private PracticeSetTemplate(string name)
    {
        Name = name;
    }

    public static PracticeSetTemplate Create(string name, IReadOnlyCollection<Word> words)
    {
        var template = new PracticeSetTemplate(name);
        template._words.AddRange(words);
        return template;
    } 
}