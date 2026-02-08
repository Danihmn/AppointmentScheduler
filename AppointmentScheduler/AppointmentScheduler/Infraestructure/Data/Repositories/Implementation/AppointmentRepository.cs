namespace AppointmentScheduler.Infraestructure.Data.Repositories.Implementation
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly DbSet<Appointment> _dbSet;

        public AppointmentRepository (ApplicationDbContext context) : base(context)
        {
            _dbSet = context.Set<Appointment>();
        }

        public async Task<IEnumerable<Appointment>> GetAllWithDetailAsync (CancellationToken cancellationToken = default)
        {
            IQueryable<Appointment> query = _dbSet;

            {
                query = query
                    .Include(appointment => (appointment).Patient)
                    .Include(appointment => (appointment).Doctor)
                    .Include(appointment => (appointment).Specialty)
                    .Include(appointment => (appointment).Secretary)
                    .Include(appointment => (appointment).Request);
            }

            return await query.ToListAsync(cancellationToken);
        }

        public Task<Appointment?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
