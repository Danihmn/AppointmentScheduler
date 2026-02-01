namespace AppointmentScheduler.Services.Contract;

public interface IRequestService
{
    Task<IEnumerable<Request>> GetRequestsAsync (CancellationToken cancellationToken = default);
    Task<Request> GetRequestByIdAsync (int id, CancellationToken cancellationToken = default);
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