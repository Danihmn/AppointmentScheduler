using AppointmentScheduler.Common;

namespace AppointmentScheduler.Commands.Doctor;

public record CreateDoctorCommand(
    string Name,
    string Crm,
    string PhoneNumber,
    string Email,
    DateTime HiringDate,
    bool Active,
    int SpecialtyId) : ICommand<Domain.Entities.Doctor>;