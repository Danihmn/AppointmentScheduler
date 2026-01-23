using AppointmentScheduler.Commands.Appointment;
using AppointmentScheduler.Common;
using AppointmentScheduler.Domain.Entities;
using AppointmentScheduler.Services.Contract;

namespace AppointmentScheduler.Services.Implementation;

public class AppointmentService(ICommandHandler<ScheduleAppointmentCommand, Appointment> commandHandler)
    : IAppointmentService
{
    public async Task<Appointment> ScheduleAppointmentAsync
    (
        DateTime date,
        int patientId,
        int doctorId,
        int specialtyId,
        int secretaryId,
        string? notes = null,
        CancellationToken cancellationToken = default
    )
    {
        if (date < DateTime.Now) throw new Exception("Invalid date");

        // It needs to check if exists the Foreign Keys

        var command = new ScheduleAppointmentCommand(date, patientId, doctorId, specialtyId, secretaryId, notes);
        return await commandHandler.Handle(command, cancellationToken);
    }
}