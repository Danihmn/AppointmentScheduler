using AppointmentScheduler.Infrastructure.Persistence.Repositories.Contract.Generic;

namespace AppointmentScheduler.Infrastructure.Persistence.Repositories.Contract
{
    public interface ISpecialtyRepository : IRepository<Specialty>
    {
        Task<IEnumerable<Specialty>> GetAllWithDetailAsync (CancellationToken cancellationToken = default);
        Task<Specialty?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default);
    }
}
