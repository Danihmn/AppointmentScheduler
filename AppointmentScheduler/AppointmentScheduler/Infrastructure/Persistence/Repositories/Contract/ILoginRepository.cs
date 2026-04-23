namespace AppointmentScheduler.Infrastructure.Persistence.Repositories.Contract
{
    public interface ILoginRepository : IRepository<Secretary>
    {
        Task<Secretary?> GetByUsername (string username, CancellationToken cancellationToken = default);
    }
}
