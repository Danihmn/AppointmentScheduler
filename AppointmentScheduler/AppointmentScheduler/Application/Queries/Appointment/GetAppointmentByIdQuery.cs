using AppointmentScheduler.Application.Common;

namespace AppointmentScheduler.Application.Queries.Appointment
{
    public record GetAppointmentByIdQuery (int Id) : IQuery<Domain.Entities.Appointment>;
}
