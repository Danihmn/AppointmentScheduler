using AppointmentScheduler.Common;
using AppointmentScheduler.Domain.Enums;

namespace AppointmentScheduler.Commands.Appointment;

public record ScheduleAppointmentCommand(
    DateTime Date,
    EStatus Status,
    int RequestId,
    int PatientId,
    int DoctorId,
    int SpecialtyId,
    int SecretaryId,
    string? Notes = null) : ICommand<Domain.Entities.Appointment>;