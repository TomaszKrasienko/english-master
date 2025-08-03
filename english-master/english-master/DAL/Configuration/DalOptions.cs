namespace english_master.DAL.Configuration;

public sealed record DalOptions
{
    public required string ConnectionString { get; init; }
}