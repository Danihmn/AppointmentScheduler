namespace AppointmentScheduler.Features.Patient.Get.GetAll
{
    public record GetPatientsQuery () : IQuery<ApiResponse<IEnumerable<PatientResponseDTO>>>;
}
