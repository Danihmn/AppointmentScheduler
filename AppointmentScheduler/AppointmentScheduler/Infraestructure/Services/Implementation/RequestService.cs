using AppointmentScheduler.Application.Commands.Request;
using AppointmentScheduler.Application.Common;
using AppointmentScheduler.Application.Queries.Request;
using AppointmentScheduler.Infraestructure.Services.Contract;

namespace AppointmentScheduler.Infraestructure.Services.Implementation;

public class RequestService

    (
        IQueryHandler<GetRequestsQuery, IEnumerable<Request>> queryHandlerGetAllRequests,
        IQueryHandler<GetRequestByIdQuery, Request> queryHandlerGetRequestById,
        ICommandHandler<CreateRequestCommand, Request> commandHandlerCreateRequest
    ) : IRequestService
{
    public async Task<IEnumerable<Request>> GetRequestsAsync (CancellationToken cancellationToken = default)
    {
        var query = new GetRequestsQuery();
        return await queryHandlerGetAllRequests.Handle(query, cancellationToken);
    }

    public async Task<Request> GetRequestByIdAsync (int id, CancellationToken cancellationToken = default)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        var query = new GetRequestByIdQuery(id);
        return await queryHandlerGetRequestById.Handle(query, cancellationToken);
    }

    public async Task<Request> CreateRequestAsync
    (
        ERequestStatus status,
        ERequestType type,
        DateTime desiredDate,
        string description,
        string notes,
        EPriority priority,
        int patientId,
        int specialtyId,
        int processedBySecretaryId,
        CancellationToken cancellationToken = default
    )
    {
        if ((status != ERequestStatus.Approved && status != ERequestStatus.Pending &&
             status != ERequestStatus.Rejected) ||
            (type != ERequestType.Cancellation &&
             type != ERequestType.Rescheduling &&
             type != ERequestType.Scheduling) || desiredDate < DateTime.Now ||
            string.IsNullOrEmpty(description) || (priority != EPriority.High && priority != EPriority.Low &&
                                                  priority != EPriority.Medium) || patientId <= 0 || specialtyId <= 0 ||
            processedBySecretaryId <= 0) throw new Exception("Invalid data");

        // It needs to check if exists the Foreign Keys

        var command = new CreateRequestCommand(status, type, desiredDate, description, notes, priority, patientId,
            specialtyId, processedBySecretaryId);

        return await commandHandlerCreateRequest.Handle(command, cancellationToken);
    }
}