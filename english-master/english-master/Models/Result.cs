namespace english_master.Models;

public sealed class Result
{
    public Guid Id { get; }
    public bool IsCorrect { get; }
    public Guid WordId  { get; }
    public Word? Word { get; }
    public int PracticeSetId { get; }
    public PracticeSet? PracticeSet { get; }

    public Result() { }

    private Result(
        Guid id,
        Guid wordId,
        bool isCorrect)
    {
        Id = id;
        WordId = wordId;
        IsCorrect = isCorrect;
    }
    
    public static Result Create(Guid id, Guid wordId, bool isCorrect)
        => new(id, wordId, isCorrect);
    
}