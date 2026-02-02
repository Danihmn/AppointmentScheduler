namespace AppointmentScheduler.Infraestructure.Extensions;

public static class EndpointExtension
{
    public static WebApplication MapEndpoints (this WebApplication app)
    {
        app.MapAppointmentEndpoints();
        app.MapDoctorEndpoints();
        app.MapPatientEndpoints();
        app.MapRequestEndpoints();
        app.MapSecretaryEndpoints();
        app.MapSpecialtyEndpoints();

        return app;
    }
}