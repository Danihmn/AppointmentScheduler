using AppointmentScheduler.Features.Common.CQRS;

namespace AppointmentScheduler.Features.Doctor.Get.GetAll
{
    public record GetDoctorsQuery () : IQuery<IEnumerable<DoctorResponseDTO>>;
}
