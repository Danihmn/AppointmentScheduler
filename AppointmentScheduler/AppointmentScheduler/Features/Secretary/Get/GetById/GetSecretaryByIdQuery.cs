namespace AppointmentScheduler.Features.Secretary.Get.GetById
{
    public record GetSecretaryByIdQuery (int Id) : IQuery<ApiResponse<SecretaryResponseDTO>>;
}
