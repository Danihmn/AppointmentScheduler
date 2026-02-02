namespace AppointmentScheduler.Infraestructure.Services.Contract;

public interface IDoctorService
{
    Task<IEnumerable<Doctor>> GetDoctorsAsync (CancellationToken cancellationToken = default);
    Task<Doctor> GetDoctorByIdAsync (int id, CancellationToken cancellationToken = default);
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