using AppointmentScheduler.Commands.Request;
using AppointmentScheduler.Common;
using AppointmentScheduler.Domain.Entities;
using AppointmentScheduler.Domain.Enums;
using AppointmentScheduler.Services.Contract;

namespace AppointmentScheduler.Services.Implementation;

public class RequestService(ICommandHandler<CreateRequestCommand, Request> commandHandler) : IRequestService
{
    public async Task<Request> AddRequestAsync
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
        
        return await commandHandler.Handle(command, cancellationToken);
    }
}