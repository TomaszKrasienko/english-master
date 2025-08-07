namespace english_master.Mutations.PracticeSetTemplates.Types;

public sealed record CreatePracticeSetTemplateInput(
    string Name,
    IReadOnlyList<Guid> Words);