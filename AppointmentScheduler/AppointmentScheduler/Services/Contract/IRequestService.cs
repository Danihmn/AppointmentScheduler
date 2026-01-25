using AppointmentScheduler.Domain.Entities;
using AppointmentScheduler.Domain.Enums;

namespace AppointmentScheduler.Services.Contract;

public interface IRequestService
{
    Task<Request> CreateRequestAsync
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
    );
}