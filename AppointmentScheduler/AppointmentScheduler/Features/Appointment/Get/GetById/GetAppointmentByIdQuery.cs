using AppointmentScheduler.Features.Common.CQRS;

namespace AppointmentScheduler.Features.Appointment.Get.GetById
{
    public record GetAppointmentByIdQuery (int Id) : IQuery<AppointmentResponseDTO>;
}
