namespace AppointmentScheduler.Features.Doctor.Update;

public record UpdateDoctorCommand (
    int Id,
    string Name,
    string Crm,
    string PhoneNumber,
    string Email,
    DateTime HiringDate,
    bool Active,
    int SpecialtyId) : ICommand<ApiResponse<DoctorResponseDTO>>;
