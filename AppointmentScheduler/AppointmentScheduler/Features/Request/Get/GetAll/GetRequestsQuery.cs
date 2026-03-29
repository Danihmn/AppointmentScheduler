namespace AppointmentScheduler.Features.Request.Get.GetAll;

public record GetRequestsQuery () : IQuery<ApiResponse<IEnumerable<RequestResponseDTO>>>;