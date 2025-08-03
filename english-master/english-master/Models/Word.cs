using System.Security.Principal;

namespace english_master.Models;

public sealed class Word
{
    private List<PracticeSetTemplate> _practiceSetTemplates = [];
    private List<Result> _results = [];
    public Guid Id { get; }
    public string Term { get; }
    public string Translation { get; }
    public Guid TopicId { get; }
    public Topic Topic { get; }
    
    public IReadOnlyCollection<PracticeSetTemplate> Sets 
        => _practiceSetTemplates.AsReadOnly();
    public IReadOnlyCollection<Result> Results 
        => _results.AsReadOnly();

    private Word() { }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    private Word(
        Guid id,
        string term,
        string translation,
        Guid topicId)
    {
        Id = id;
        Term = term;
        Translation = translation;
        TopicId = topicId;
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    
    public static Word Create(
        Guid id,
        string term,
        string translation,
        Guid topicId)
        => new(id, term, translation, topicId);
}