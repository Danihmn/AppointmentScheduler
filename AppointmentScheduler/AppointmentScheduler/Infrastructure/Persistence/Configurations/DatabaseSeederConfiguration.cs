namespace AppointmentScheduler.Infrastructure.Persistence.Configurations;

public static class DatabaseSeederConfiguration
{
    public static async Task SeedDatabaseAsync (this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasherService>();

        await context.Database.MigrateAsync();

        var hasAdmin = await context.Secretaries.AnyAsync(secretary => secretary.Role == ERole.Admin);

        if (hasAdmin) return;

        const string defaultPassword = "Admin@1234";

        var admin = new Secretary
        {
            Username = "admin",
            HashedPassword = passwordHasher.Hash(defaultPassword),
            Name = "Administrador",
            Cpf = "00000000000",
            PhoneNumber = "00000000000",
            Email = "admin@admin.com",
            HiringDate = DateTime.UtcNow,
            IsActive = true,
            Role = ERole.Admin,
        };

        context.Secretaries.Add(admin);
        await context.SaveChangesAsync();

        app.Logger.LogWarning(
            "Usuário admin criado pelo seeder. Username: admin | Password: {Password} — altere após o primeiro acesso.",
            defaultPassword);
    }
}
