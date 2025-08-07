using english_master.Models;

namespace english_master.Graph.Types;

public sealed class ResultType : ObjectType<Result>
{
    protected override void Configure(IObjectTypeDescriptor<Result> descriptor)
    {
        descriptor.Description("Represents a result of answering a word in a practice set");

        descriptor
            .Field(r => r.Id)
            .Type<NonNullType<UuidType>>()
            .Description("The unique identifier of the result");

        descriptor
            .Field(r => r.IsCorrect)
            .Type<NonNullType<BooleanType>>()
            .Description("Whether the answer was correct");

        descriptor
            .Field(r => r.WordId)
            .Type<NonNullType<UuidType>>()
            .Description("The identifier of the word being tested");

        descriptor
            .Field(r => r.Word)
            .Description("The word associated with this result");

        descriptor
            .Field(r => r.PracticeSetId)
            .Type<NonNullType<IntType>>()
            .Description("The identifier of the practice set this result belongs to");

        descriptor
            .Field(r => r.PracticeSet)
            .Description("The practice set associated with this result");
    }
}