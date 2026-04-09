namespace AppointmentScheduler;

public class Program
{
    public static async Task Main (string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddMapsterConfiguration();

        builder.Services.AddDatabaseConfiguration(builder.Configuration);

        builder.Services.AddAuthenticationConfiguration();

        builder.Services.AddAuthorization();

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddScoped<TokenConfiguration>();
        builder.Services.AddScoped<ITokenService, TokenService>();

        builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();

        builder.Services.MapCommandHandlers();
        builder.Services.MapQueryHandlers();

        builder.Services.AddProblemDetails();
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

        builder.Services.AddOpenApi();

        var app = builder.Build();
        var isDevelopment = app.Environment.IsDevelopment();

        await app.SeedDatabaseAsync();

        if (isDevelopment)
            app.MapOpenApi();

        if (!isDevelopment)
            app.UseHttpsRedirection();

        app.UseExceptionHandler();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapEndpoints();

        app.UseScalarDocumentation();

        var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

        app.Run($"http://*:{port}");
    }
}

