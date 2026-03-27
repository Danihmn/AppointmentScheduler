using AppointmentScheduler.Features.Common.CQRS;

namespace AppointmentScheduler.Features.Request.Get.GetById;

public record GetRequestByIdQuery (int Id) : IQuery<RequestResponseDTO>;