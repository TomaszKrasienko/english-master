namespace english_master.Models;

public sealed class PracticeSet
{
    private readonly List<Result> _results = [];
    public int Id { get; }
    public string Name { get; }
    public DateTimeOffset CreatedAt { get; }
    public IReadOnlyCollection<Result> Results => _results.AsReadOnly();

    private PracticeSet(int id, string name, DateTimeOffset createdAt)
    {
        Id = id;
        Name = name;
        CreatedAt = createdAt;
    }

    public static PracticeSet Create(int id, string name, DateTimeOffset createdAt, List<Word> words)
        => new(id, name, createdAt);
}