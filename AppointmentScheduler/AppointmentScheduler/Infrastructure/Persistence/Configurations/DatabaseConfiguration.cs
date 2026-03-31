namespace AppointmentScheduler.Infrastructure.Persistence.Configurations;

public static class DatabaseConfiguration
{
    public static IServiceCollection AddDatabaseConfiguration (this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration["ConnectionStrings:DefaultConnection"];

        if (string.IsNullOrEmpty(connectionString))
            throw new Exception("No connection string found in the configuration file");

        services.AddDbContext<AppDbContext.ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        return services;
    }
}