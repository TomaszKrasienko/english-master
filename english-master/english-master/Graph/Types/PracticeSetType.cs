using english_master.Models;

namespace english_master.Graph.Types;

public sealed class PracticeSetType : ObjectType<PracticeSet>
{
    protected override void Configure(IObjectTypeDescriptor<PracticeSet> descriptor)
    {
        descriptor.Description("Represents a practice set with words to learn and results");

        descriptor
            .Field(p => p.Id)
            .Type<NonNullType<IntType>>()
            .Description("The unique identifier of the practice set");

        descriptor
            .Field(p => p.Name)
            .Type<NonNullType<StringType>>()
            .Description("The name of the practice set");

        descriptor
            .Field(p => p.CreatedAt)
            .Type<NonNullType<DateTimeType>>()
            .Description("The date and time when the practice set was created");

        descriptor
            .Field(p => p.Results)
            .Description("The results associated with this practice set");
    }
}