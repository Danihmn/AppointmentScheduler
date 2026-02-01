namespace AppointmentScheduler.Configurations;

public static class ScalarConfiguration
{
    private static readonly string AppName = "API APPOINTMENT SCHEDULER";

    public static WebApplication UseScalarDocumentation (this WebApplication app)
    {
        app.MapScalarApiReference("/scalar", options =>
        {
            options
                .WithTitle(AppName)
                .WithOpenApiRoutePattern("/openapi/v1.json");
        });

        return app;
    }
}