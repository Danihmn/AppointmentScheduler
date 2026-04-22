namespace AppointmentScheduler.Infrastructure.Persistence.Configurations;

public static class ScalarConfiguration
{
    public static WebApplication UseScalarDocumentation (this WebApplication app)
    {
        app.MapScalarApiReference("/scalar", options =>
        {
            options
                .WithTitle("APPOINTMENT SCHEDULER API")
                .WithOpenApiRoutePattern("/openapi/v1.json");
        });

        return app;
    }
}