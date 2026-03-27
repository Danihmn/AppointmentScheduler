using AppointmentScheduler.Infraestructure.Persistence.Repositories.Contract.Generic;

namespace AppointmentScheduler.Infraestructure.Persistence.Repositories.Contract
{
    public interface ILoginRepository : IRepository<Secretary>
    {
        Task<Secretary?> GetByUsername (string username, CancellationToken cancellationToken = default);
    }
}
