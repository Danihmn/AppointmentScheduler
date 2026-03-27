using AppointmentScheduler.Features.Common.CQRS;

namespace AppointmentScheduler.Features.Patient.Get.GetById
{
    public record GetPatientByIdQuery (int Id) : IQuery<PatientResponseDTO>;
}
