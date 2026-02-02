using AppointmentScheduler.Application.Common;

namespace AppointmentScheduler.Application.Commands.Doctor;

public record CreateDoctorCommand (
    string Name,
    string Crm,
    string PhoneNumber,
    string Email,
    DateTime HiringDate,
    bool Active,
    int SpecialtyId) : ICommand<Domain.Entities.Doctor>;