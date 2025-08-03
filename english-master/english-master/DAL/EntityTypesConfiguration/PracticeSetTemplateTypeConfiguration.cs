using english_master.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace english_master.DAL.EntityTypesConfiguration;

internal sealed class PracticeSetTemplateTypeConfiguration : IEntityTypeConfiguration<PracticeSetTemplate>
{
    public void Configure(EntityTypeBuilder<PracticeSetTemplate> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(p => p.Name)
            .IsRequired();

        builder
            .HasMany(x => x.Words)
            .WithMany(x => x.Sets);
    }
}