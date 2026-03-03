namespace AppointmentScheduler.Configurations;

public static class EndpointConfiguration
{
    public static WebApplication MapEndpoints (this WebApplication app)
    {
        app.MapAppointmentEndpoints();
        app.MapDoctorEndpoints();
        app.MapPatientEndpoints();
        app.MapRequestEndpoints();
        app.MapSecretaryEndpoints();
        app.MapSpecialtyEndpoints();
        app.MapLoginEndpoints();

        return app;
    }
}