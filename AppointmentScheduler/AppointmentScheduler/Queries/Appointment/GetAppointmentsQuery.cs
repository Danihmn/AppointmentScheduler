using AppointmentScheduler.Common;
using AppointmentScheduler.Domain.Enums;

namespace AppointmentScheduler.Queries.Appointment
{
    public record GetAppointmentsQuery (
        int id,
        DateTime Date,
        EStatus Status,
        int RequestId,
        int PatientId,
        int DoctorId,
        int SpecialtyId,
        int SecretaryId,
        string? Notes = null) : IQuery<IEnumerable<Domain.Entities.Appointment>>;
}
