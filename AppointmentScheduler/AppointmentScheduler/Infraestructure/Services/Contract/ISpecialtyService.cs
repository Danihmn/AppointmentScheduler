namespace AppointmentScheduler.Infraestructure.Services.Contract;

public interface ISpecialtyService
{
    Task<IEnumerable<Specialty>> GetSpecialtiesAsync (CancellationToken cancellationToken = default);
    Task<Specialty> GetSpecialtyByIdAsync (int id, CancellationToken cancellationToken = default);
    Task<Specialty> CreateSpecialtyAsync
    (
        string description,
        bool isActive,
        CancellationToken cancellationToken = default
    );
}