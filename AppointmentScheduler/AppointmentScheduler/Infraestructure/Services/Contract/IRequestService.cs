namespace AppointmentScheduler.Infraestructure.Services.Contract;

public interface IRequestService
{
    Task<IEnumerable<RequestResponseDTO>> GetRequestsAsync (CancellationToken cancellationToken = default);
    Task<RequestResponseDTO> GetRequestByIdAsync (int id, CancellationToken cancellationToken = default);
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