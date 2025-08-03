using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace english_master.DAL.Configuration;

internal static class DalConfigurationExtensions
{
    internal static IServiceCollection AddDal(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .AddOptions(configuration)
            .AddContext()
            .AddMigrator()
            .AddSeeder();

    private static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        => services.Configure<DalOptions>(configuration.GetSection(nameof(DalOptions)));

    private static IServiceCollection AddContext(
        this IServiceCollection services)
    {
        services.AddDbContext<EnglishMasterDbContext>((sp, options) =>
        {
            var postgresOptions = sp.GetRequiredService<IOptions<DalOptions>>();
            options.UseNpgsql(postgresOptions.Value.ConnectionString);
        });
        
        return services;
    }

    private static IServiceCollection AddMigrator(this IServiceCollection services)
        => services.AddHostedService<DatabaseMigrator>();

    private static IServiceCollection AddSeeder(this IServiceCollection services)
        => services.AddHostedService<DataSeeder>();
}