namespace AppointmentScheduler.Infraestructure.Data.Repositories.Contract
{
    public interface ILoginRepository : IRepository<Secretary>
    {
        Task<Secretary?> GetByUsername (string username, CancellationToken cancellationToken = default);
    }
}
