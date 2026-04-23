namespace AppointmentScheduler.Infrastructure.Persistence.Repositories.Contract
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> GetAllWithDetailAsync (CancellationToken cancellationToken = default);
        Task<Doctor?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default);
    }
}