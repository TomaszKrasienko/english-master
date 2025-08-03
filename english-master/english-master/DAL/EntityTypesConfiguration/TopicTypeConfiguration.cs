using english_master.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace english_master.DAL.EntityTypesConfiguration;

internal sealed class TopicTypeConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasMaxLength(36)
            .IsRequired();

        builder
            .Property(x => x.Name)
            .IsRequired();

        builder
            .HasMany(x => x.Words)
            .WithOne(x => x.Topic)
            .HasForeignKey(x => x.TopicId);
    }
}