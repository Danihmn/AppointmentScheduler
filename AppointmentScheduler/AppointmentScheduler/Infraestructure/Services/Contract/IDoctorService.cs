namespace AppointmentScheduler.Infraestructure.Services.Contract;

public interface IDoctorService
{
    Task<IEnumerable<DoctorResponseDTO>> GetDoctorsAsync (CancellationToken cancellationToken = default);
    Task<DoctorResponseDTO> GetDoctorByIdAsync (int id, CancellationToken cancellationToken = default);
    Task<Doctor> CreateDoctorAsync
    (
        string name,
        string crm,
        string phoneNumber,
        string email,
        DateTime hiringDate,
        bool active,
        int specialtyId,
        CancellationToken cancellationToken = default
    );
}