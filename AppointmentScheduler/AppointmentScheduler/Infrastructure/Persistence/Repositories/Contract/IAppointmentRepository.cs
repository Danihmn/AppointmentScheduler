namespace AppointmentScheduler.Infrastructure.Persistence.Repositories.Contract
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAllWithDetailAsync (CancellationToken cancellationToken = default);
        Task<Appointment?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default);
        Task<bool> HasConflictAsync (int doctorId, DateTime date, CancellationToken cancellationToken = default);
    }
}
