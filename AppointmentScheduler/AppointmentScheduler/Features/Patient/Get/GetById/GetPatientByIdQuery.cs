namespace AppointmentScheduler.Features.Patient.Get.GetById
{
    public record GetPatientByIdQuery (int Id) : IQuery<ApiResponse<PatientResponseDTO>>;
}
