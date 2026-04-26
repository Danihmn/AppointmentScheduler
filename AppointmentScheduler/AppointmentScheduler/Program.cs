

using Azure;

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

        builder.Services.AddSignalR();

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

        builder.Services.AddScoped<TokenConfiguration>();
        builder.Services.AddScoped<ITokenService, TokenService>();

        builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();

        builder.Services.AddScoped<INotificationService, NotificationService>();

        builder.Services.AddScoped<AppointmentTools>();

        builder.Services.AddSingleton(_ =>
            new AzureOpenAIClient(
                new Uri(builder.Configuration["AzureOpenAI:Endpoint"]!),
                new AzureKeyCredential(builder.Configuration["AzureOpenAI:ApiKey"]!)));

        builder.Services.AddScoped<IAgentService, AgentService>();

        builder.Services.MapCommandHandlers();
        builder.Services.MapQueryHandlers();

        builder.Services.AddProblemDetails();
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

        builder.Services.AddOpenApi();

        var app = builder.Build();
        var isDevelopment = app.Environment.IsDevelopment();

        await app.SeedDatabaseAsync();

        app.MapOpenApi();

        if (!isDevelopment && string.IsNullOrEmpty(Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME")))
            app.UseHttpsRedirection();

        app.UseExceptionHandler();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapEndpoints();

        app.MapHub<NotificationHub>("/hubs/notifications");

        app.UseScalarDocumentation();

        app.Run();
    }
}

