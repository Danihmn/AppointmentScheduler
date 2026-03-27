using AppointmentScheduler.Features.Common.CQRS;

namespace AppointmentScheduler.Features.Secretary.Get.GetAll
{
    public record GetSecretariesQuery () : IQuery<IEnumerable<SecretaryResponseDTO>>;
}
