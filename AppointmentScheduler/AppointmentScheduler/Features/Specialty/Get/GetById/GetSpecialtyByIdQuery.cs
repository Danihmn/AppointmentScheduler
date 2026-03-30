namespace AppointmentScheduler.Features.Specialty.Get.GetById
{
    public record GetSpecialtyByIdQuery (int Id) : IQuery<ApiResponse<SpecialtyResponseDTO>>;
}
