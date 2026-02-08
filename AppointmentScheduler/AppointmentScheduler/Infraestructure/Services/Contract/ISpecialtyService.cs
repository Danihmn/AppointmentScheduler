namespace AppointmentScheduler.Infraestructure.Services.Contract;

public interface ISpecialtyService
{
    Task<IEnumerable<SpecialtyResponseDTO>> GetSpecialtiesAsync (CancellationToken cancellationToken = default);
    Task<SpecialtyResponseDTO> GetSpecialtyByIdAsync (int id, CancellationToken cancellationToken = default);
    Task<Specialty> CreateSpecialtyAsync
    (
        string description,
        bool isActive,
        CancellationToken cancellationToken = default
    );
}