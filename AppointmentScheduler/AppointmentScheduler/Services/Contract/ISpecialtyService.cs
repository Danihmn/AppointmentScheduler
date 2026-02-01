namespace AppointmentScheduler.Services.Contract;

public interface ISpecialtyService
{
    Task<Specialty> CreateSpecialtyAsync
    (
        string description,
        bool isActive,
        CancellationToken cancellationToken = default
    );
}