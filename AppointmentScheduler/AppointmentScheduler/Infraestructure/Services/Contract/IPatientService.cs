namespace AppointmentScheduler.Infraestructure.Services.Contract;

public interface IPatientService
{
    Task<IEnumerable<PatientResponseDTO>> GetPatientsAsync (CancellationToken cancellationToken = default);
    Task<PatientResponseDTO> GetPatientByIdAsync (int id, CancellationToken cancellationToken = default);
    Task<Patient> CreatePatientAsync
    (
        string name,
        string cpf,
        string phoneNumber,
        string email,
        EGender gender,
        string? notes,
        CancellationToken cancellationToken = default
    );
}