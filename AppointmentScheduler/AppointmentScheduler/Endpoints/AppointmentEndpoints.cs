using AppointmentScheduler.Commands.Appointment;
using AppointmentScheduler.Services.Contract;

namespace AppointmentScheduler.Endpoints;

public static class AppointmentEndpoints
{
    public static Task<WebApplication> MapAppointmentEndpoints(this WebApplication app)
    {
        var appointmentGroup = app.MapGroup("/api/appointments").WithTags("Appointments");

        appointmentGroup.MapPost("/schedule",
            async (ScheduleAppointmentCommand command, IAppointmentService appointmentService) =>
                await appointmentService.ScheduleAppointmentAsync(command.Date, command.Status, command.RequestId,
                    command.PatientId, command.DoctorId, command.SpecialtyId, command.SecretaryId));

        return Task.FromResult(app);
    }
}