using AppointmentScheduler.Common;
using AppointmentScheduler.Domain.Enums;

namespace AppointmentScheduler.Commands.Patient;

public record CreatePatientCommand(
    string Name,
    string Cpf,
    string PhoneNumber,
    string Email,
    EGender Gender,
    string? Notes
) : ICommand<Domain.Entities.Patient>;