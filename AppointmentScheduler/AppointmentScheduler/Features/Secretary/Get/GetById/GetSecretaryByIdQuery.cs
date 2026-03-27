using AppointmentScheduler.Features.Common.CQRS;

namespace AppointmentScheduler.Features.Secretary.Get.GetById
{
    public record GetSecretaryByIdQuery (int Id) : IQuery<SecretaryResponseDTO>;
}
