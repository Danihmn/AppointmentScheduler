using AppointmentScheduler.Common;

namespace AppointmentScheduler.Commands.Appointment;

public record ScheduleAppointmentCommand(
    DateTime Date,
    int PatientId,
    int DoctorId,
    int SpecialtyId,
    int SecretaryId,
    string? Notes = null) : ICommand<Domain.Entities.Appointment>;