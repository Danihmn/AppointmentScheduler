using AppointmentScheduler.Infraestructure.Persistence.Repositories.Contract.Generic;

namespace AppointmentScheduler.Infraestructure.Persistence.Repositories.Contract
{
    public interface IRequestRepository : IRepository<Request>
    {
        Task<IEnumerable<Request>> GetAllWithDetailAsync (CancellationToken cancellationToken = default);
        Task<Request?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default);
    }
}
