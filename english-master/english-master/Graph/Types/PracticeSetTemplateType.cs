using english_master.Models;

namespace english_master.Graph.Types;

public sealed class PracticeSetTemplateType : ObjectType<PracticeSetTemplate>
{
    protected override void Configure(IObjectTypeDescriptor<PracticeSetTemplate> descriptor)
    {
        descriptor.Description("Represents a template for practice sets");

        descriptor
            .Field(t => t.Id)
            .Type<NonNullType<IntType>>()
            .Description("The unique identifier of the practice set template");

        descriptor
            .Field(t => t.Name)
            .Type<NonNullType<StringType>>()
            .Description("The name of the practice set template");

        descriptor
            .Field(t => t.Words)
            .UseProjection()
            .Description("The words included in this practice set template");
    }
}