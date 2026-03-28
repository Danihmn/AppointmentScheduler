namespace AppointmentScheduler.API.Endpoints;

public static class AppointmentEndpoints
{
    public static WebApplication MapAppointmentEndpoints (this WebApplication app)
    {
        RouteGroupBuilder appointmentGroup = app.MapGroup("/api/appointments").WithTags("Appointments").RequireAuthorization();

        appointmentGroup.MapGet("/appointment", async
            (IQueryHandler<GetAppointmentsQuery, IEnumerable<AppointmentResponseDTO>> queryHandlerGetAllAppointments, CancellationToken cancellationToken = default) =>
            await queryHandlerGetAllAppointments.Handle(new GetAppointmentsQuery(), cancellationToken)).WithDescription("Lista todas as consultas");

        appointmentGroup.MapGet("/appointment/{id}", async (IQueryHandler<GetAppointmentByIdQuery, AppointmentResponseDTO> queryHandlerGetAppointmentById, int id, CancellationToken cancellationToken = default) =>
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

            return await queryHandlerGetAppointmentById.Handle(new GetAppointmentByIdQuery(id), cancellationToken);
        }).WithDescription("Exibe consulta por Id");

        appointmentGroup.MapPost("/appointment",
            async (ScheduleAppointmentCommand command, ICommandHandler<ScheduleAppointmentCommand, Appointment> commandHandlerCreateAppointment, CancellationToken cancellationToken = default) =>
            await commandHandlerCreateAppointment.Handle(command, cancellationToken))
            .WithDescription("Cria nova consulta")
            .RequireAuthorization(policy => policy.RequireRole("Admin"));

        return app;
    }
}