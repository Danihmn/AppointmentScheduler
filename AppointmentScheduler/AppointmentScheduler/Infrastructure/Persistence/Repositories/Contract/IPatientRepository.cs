namespace AppointmentScheduler.Infrastructure.Persistence.Repositories.Contract
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<IEnumerable<Patient>> GetAllWithDetailAsync (CancellationToken cancellationToken = default);
        Task<Patient?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default);
    }
}
