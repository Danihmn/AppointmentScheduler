namespace AppointmentScheduler.Infraestructure.Data.Repositories.Contract
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAllWithDetailAsync (CancellationToken cancellationToken = default);
        Task<Appointment?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default);
    }
}
