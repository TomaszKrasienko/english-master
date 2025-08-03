namespace english_master.DTOs.Words.Requests;

public sealed record CreateWordRequestDto(
    string Term,
    string Translation,
    Guid TopicId);