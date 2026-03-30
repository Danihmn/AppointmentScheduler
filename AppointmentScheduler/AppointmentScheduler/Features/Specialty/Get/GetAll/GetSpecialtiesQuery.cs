namespace AppointmentScheduler.Features.Specialty.Get.GetAll
{
    public record GetSpecialtiesQuery () : IQuery<ApiResponse<IEnumerable<SpecialtyResponseDTO>>>;
}
