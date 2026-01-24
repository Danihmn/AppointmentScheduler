using AppointmentScheduler.Endpoints;

namespace AppointmentScheduler.Extensions;

public static class EndpointExtension
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        app.MapAppointmentEndpoints();

        return app;
    }
}