using AppointmentScheduler.Features.Common.CQRS;

namespace AppointmentScheduler.Features.Specialty.Get.GetById
{
    public record GetSpecialtyByIdQuery (int Id) : IQuery<SpecialtyResponseDTO>;
}
