using AppointmentScheduler.Features.Common.CQRS;

namespace AppointmentScheduler.Features.Specialty.Get.GetAll
{
    public record GetSpecialtiesQuery () : IQuery<IEnumerable<SpecialtyResponseDTO>>;
}
