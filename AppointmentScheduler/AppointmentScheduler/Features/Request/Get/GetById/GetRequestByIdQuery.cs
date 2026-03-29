namespace AppointmentScheduler.Features.Request.Get.GetById;

public record GetRequestByIdQuery (int Id) : IQuery<ApiResponse<RequestResponseDTO>>;