namespace AppointmentScheduler.Features.Doctor.Create;

public record CreateDoctorCommand (
    string Name,
    string Crm,
    string PhoneNumber,
    string Email,
    DateTime HiringDate,
    bool Active,
    int SpecialtyId) : ICommand<ApiResponse<DoctorResponseDTO>>;