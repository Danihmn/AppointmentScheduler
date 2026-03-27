using AppointmentScheduler.Features.Common.CQRS;

namespace AppointmentScheduler.Features.Doctor.Create;

public record CreateDoctorCommand (
    string Name,
    string Crm,
    string PhoneNumber,
    string Email,
    DateTime HiringDate,
    bool Active,
    int SpecialtyId) : ICommand<Domain.Entities.Doctor>;