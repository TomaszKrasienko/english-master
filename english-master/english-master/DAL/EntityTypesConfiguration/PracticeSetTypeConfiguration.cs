using english_master.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace english_master.DAL.EntityTypesConfiguration;

internal sealed class PracticeSetTypeConfiguration : IEntityTypeConfiguration<PracticeSet>
{
    public void Configure(EntityTypeBuilder<PracticeSet> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .IsRequired();
    }
}