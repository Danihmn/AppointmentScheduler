namespace AppointmentScheduler.Features.Appointment.Get.GetById
{
    public record GetAppointmentByIdQuery (int Id) : IQuery<ApiResponse<AppointmentResponseDTO>>;
}
