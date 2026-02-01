using AppointmentScheduler.Common;

namespace AppointmentScheduler.Queries.Request;

public record GetRequestByIdQuery (int Id) : IQuery<Domain.Entities.Request>;