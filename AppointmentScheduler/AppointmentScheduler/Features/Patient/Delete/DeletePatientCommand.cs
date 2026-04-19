namespace AppointmentScheduler.Features.Patient.Delete;

public record DeletePatientCommand (int Id) : ICommand<ApiResponse<PatientResponseDTO>>;
