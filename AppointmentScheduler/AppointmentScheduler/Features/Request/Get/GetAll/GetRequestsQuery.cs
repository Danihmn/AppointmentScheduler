using AppointmentScheduler.Features.Common.CQRS;

namespace AppointmentScheduler.Features.Request.Get.GetAll;

public record GetRequestsQuery () : IQuery<IEnumerable<RequestResponseDTO>>;