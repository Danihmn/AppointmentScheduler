namespace AppointmentScheduler.Features.Appointment.Get.GetAll
{
    public record GetAppointmentsQuery () : IQuery<ApiResponse<IEnumerable<AppointmentResponseDTO>>>;
}
