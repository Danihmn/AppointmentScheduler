using AppointmentScheduler.Features.Common.CQRS;

namespace AppointmentScheduler.Features.Appointment.Get.GetAll
{
    public record GetAppointmentsQuery () : IQuery<IEnumerable<AppointmentResponseDTO>>;
}
