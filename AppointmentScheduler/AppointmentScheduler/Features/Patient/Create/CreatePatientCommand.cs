namespace AppointmentScheduler.Features.Patient.Create;

public record CreatePatientCommand (
    string Name,
    string Cpf,
    string PhoneNumber,
    string Email,
    EGender Gender,
    string? Notes
) : ICommand<ApiResponse<PatientResponseDTO>>;