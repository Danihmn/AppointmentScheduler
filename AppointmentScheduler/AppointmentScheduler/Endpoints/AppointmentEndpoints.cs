using AppointmentScheduler.Commands.Appointment;
using AppointmentScheduler.Services.Contract;

namespace AppointmentScheduler.Endpoints;

public static class AppointmentEndpoints
{
    public static Task<WebApplication> MapAppointmentEndpoints (this WebApplication app)
    {
        RouteGroupBuilder appointmentGroup = app.MapGroup("/api/appointments").WithTags("Appointments");

        appointmentGroup.MapGet("/appointment", async (IAppointmentService service) =>
            await service.GetAppointmentsAsync()).WithDescription("Lista todas as consultas");

        appointmentGroup.MapGet("/appointment/{id}", async (IAppointmentService service, int id) =>
            await service.GetAppointmentByIdAsync(id)).WithDescription("Exibe consulta por Id");

        appointmentGroup.MapPost("/appointment",
            async (ScheduleAppointmentCommand command, IAppointmentService service) =>
                await service.ScheduleAppointmentAsync(command.Date, command.Status, command.RequestId,
                    command.PatientId, command.DoctorId, command.SpecialtyId, command.SecretaryId)).WithDescription("Cria nova consulta");

        return Task.FromResult(app);
    }
}