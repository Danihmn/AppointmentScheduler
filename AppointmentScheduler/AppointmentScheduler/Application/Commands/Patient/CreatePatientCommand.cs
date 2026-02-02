using AppointmentScheduler.Application.Common;

namespace AppointmentScheduler.Application.Commands.Patient;

public record CreatePatientCommand (
    string Name,
    string Cpf,
    string PhoneNumber,
    string Email,
    EGender Gender,
    string? Notes
) : ICommand<Domain.Entities.Patient>;