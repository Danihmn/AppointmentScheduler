namespace AppointmentScheduler.Features.Doctor.Get.GetById
{
    public record GetDoctorByIdQuery (int Id) : IQuery<ApiResponse<DoctorResponseDTO>>;
}
