using AppointmentScheduler.Domain.Entities;

namespace AppointmentScheduler.Services.Contract;

public interface ISpecialtyService
{
    Task<Specialty> AddSpecialty(
        string description, bool isActive, CancellationToken cancellationToken = default
    );
}