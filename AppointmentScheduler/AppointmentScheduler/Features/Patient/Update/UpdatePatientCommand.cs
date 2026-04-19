namespace AppointmentScheduler.Features.Patient.Update;

public record UpdatePatientCommand (
    int Id,
    string Name,
    string Cpf,
    string PhoneNumber,
    string Email,
    EGender Gender,
    string? Notes = null) : ICommand<ApiResponse<PatientResponseDTO>>;
