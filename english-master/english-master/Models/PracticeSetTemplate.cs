namespace english_master.Models;

public class PracticeSetTemplate
{
    private readonly List<Word> _words = [];
    public int Id { get; }
    public string Name { get; }
    public IReadOnlyCollection<Word> Words => _words.AsReadOnly();

    private PracticeSetTemplate() { }
    
    private PracticeSetTemplate(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public static PracticeSetTemplate Create(int id, string name)
        => new(id, name);
}