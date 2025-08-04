using english_master.Models;

namespace english_master.Graph.Types;

public sealed class WordType : ObjectType<Word>
{
    protected override void Configure(IObjectTypeDescriptor<Word> descriptor)
    {
        descriptor.Description("Represents a word with its translation");

        descriptor
            .Field(w => w.Id)
            .Type<NonNullType<UuidType>>()
            .Description("The unique identifier of the word");

        descriptor
            .Field(w => w.Term)
            .Type<NonNullType<StringType>>()
            .Description("The original term/word");

        descriptor
            .Field(w => w.Translation)
            .Type<NonNullType<StringType>>()
            .Description("The translation of the word");
        
        descriptor
            .Field(x => x.Topic)
            .Type<ObjectType<Topic>>()
            .Description("The topic of the word");

        descriptor
            .Field(w => w.Sets)
            .Description("The sets which include the word");

        descriptor
            .Field(x => x.Results)
            .Ignore();
    }
}