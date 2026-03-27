using AppointmentScheduler.Features.Common.CQRS;

namespace AppointmentScheduler.Features.Doctor.Get.GetById
{
    public record GetDoctorByIdQuery (int Id) : IQuery<DoctorResponseDTO>;
}
