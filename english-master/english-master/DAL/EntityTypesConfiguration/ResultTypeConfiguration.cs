using english_master.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace english_master.DAL.EntityTypesConfiguration;

internal sealed class ResultTypeConfiguration : IEntityTypeConfiguration<Result>
{
    public void Configure(EntityTypeBuilder<Result> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasMaxLength(36)
            .IsRequired();
        
        builder
            .Property(x => x.IsCorrect)
            .IsRequired();

        builder
            .HasOne(x => x.Word)
            .WithMany(x => x.Results)
            .HasForeignKey(x => x.WordId);
        
        builder
            .HasOne(x => x.PracticeSet)
            .WithMany(x => x.Results)
            .HasForeignKey(x => x.PracticeSetId);
    }
}