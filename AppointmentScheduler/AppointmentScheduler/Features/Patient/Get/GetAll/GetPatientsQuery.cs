using AppointmentScheduler.Features.Common.CQRS;

namespace AppointmentScheduler.Features.Patient.Get.GetAll
{
    public record GetPatientsQuery () : IQuery<IEnumerable<PatientResponseDTO>>;
}
