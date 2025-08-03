namespace english_master.Models;

public sealed class Topic
{
    private readonly List<Word> _words = [];
    
    public Guid Id { get; }
    public string Name { get; }
    public IReadOnlyCollection<Word> Words => _words.AsReadOnly();

    private Topic(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Topic Create(Guid id, string name) => new(id, name);
}