namespace AppointmentScheduler.Infraestructure.Data.Repositories.Contract
{
    public interface ISecretaryRepository : IRepository<Secretary>
    {
        Task<IEnumerable<Secretary>> GetAllWithDetailAsync (CancellationToken cancellationToken = default);
        Task<Secretary?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default);
    }
}
