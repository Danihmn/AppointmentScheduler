namespace AppointmentScheduler.Features.Doctor.Get.GetAll
{
    public record GetDoctorsQuery () : IQuery<ApiResponse<IEnumerable<DoctorResponseDTO>>>;
}
