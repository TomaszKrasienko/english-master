using english_master.Models;
using english_master.Queries;

namespace english_master.Graph.Types;

public sealed class TopicType : ObjectType<Topic>
{
    protected override void Configure(IObjectTypeDescriptor<Topic> descriptor)
    {
        descriptor.Description("Represents a topic that categorizes words");

        descriptor
            .Field(t => t.Id)
            .Type<NonNullType<UuidType>>()
            .Description("The unique identifier of the topic");

        descriptor
            .Field(t => t.Name)
            .Type<NonNullType<StringType>>()
            .Description("The name of the topic");

        descriptor
            .Field(t => t.Words)
            .Description("The words belonging to this topic");
    }
}