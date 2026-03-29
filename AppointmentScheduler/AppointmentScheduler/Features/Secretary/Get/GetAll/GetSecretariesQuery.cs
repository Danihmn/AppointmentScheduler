namespace AppointmentScheduler.Features.Secretary.Get.GetAll
{
    public record GetSecretariesQuery () : IQuery<ApiResponse<IEnumerable<SecretaryResponseDTO>>>;
}
