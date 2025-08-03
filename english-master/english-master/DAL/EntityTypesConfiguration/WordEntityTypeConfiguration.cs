using english_master.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace english_master.DAL.EntityTypesConfiguration;

internal sealed class WordEntityTypeConfiguration : IEntityTypeConfiguration<Word>
{
    public void Configure(EntityTypeBuilder<Word> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .HasMaxLength(36)
            .IsRequired();

        builder
            .Property(x => x.Term)
            .IsRequired();
        
        builder
            .Property(x => x.Translation)
            .IsRequired();
        
        builder
            .HasOne(x => x.Topic)
            .WithMany(x => x.Words)
            .HasForeignKey(x => x.TopicId);
    }
}