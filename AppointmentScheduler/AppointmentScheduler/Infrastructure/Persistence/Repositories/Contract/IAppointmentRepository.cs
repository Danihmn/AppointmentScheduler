using AppointmentScheduler.Infrastructure.Persistence.Repositories.Contract.Generic;

namespace AppointmentScheduler.Infrastructure.Persistence.Repositories.Contract
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAllWithDetailAsync (CancellationToken cancellationToken = default);
        Task<Appointment?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default);
    }
}
