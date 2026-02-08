namespace AppointmentScheduler.Infraestructure.Data.Repositories.Contract
{
    public interface ISpecialtyRepository : IRepository<Specialty>
    {
        Task<IEnumerable<Specialty>> GetAllWithDetailAsync (CancellationToken cancellationToken = default);
        Task<Specialty?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default);
    }
}
