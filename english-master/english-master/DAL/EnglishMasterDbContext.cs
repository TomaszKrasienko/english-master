using english_master.DAL.EntityTypesConfiguration;
using english_master.Models;
using Microsoft.EntityFrameworkCore;

namespace english_master.DAL;

public sealed class EnglishMasterDbContext(DbContextOptions<EnglishMasterDbContext> context)
    : DbContext(context)
{
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Word> Words { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new PracticeSetTypeConfiguration())
            .ApplyConfiguration(new ResultTypeConfiguration())
            .ApplyConfiguration(new TopicTypeConfiguration())
            .ApplyConfiguration(new WordEntityTypeConfiguration())
            .ApplyConfiguration(new PracticeSetTemplateTypeConfiguration());
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<Guid>()
            .HaveConversion<GuidValueConverter>();
    }
}