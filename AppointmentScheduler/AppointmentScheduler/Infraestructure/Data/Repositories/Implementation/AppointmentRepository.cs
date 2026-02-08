namespace AppointmentScheduler.Infraestructure.Data.Repositories.Implementation
{
    public class AppointmentRepository (ApplicationDbContext context)
        : Repository<Appointment>(context), IAppointmentRepository
    {
        private readonly DbSet<Appointment> _dbSet = context.Set<Appointment>();

        public async Task<IEnumerable<Appointment>> GetAllWithDetailAsync (CancellationToken cancellationToken = default)
        => await _dbSet
            .Include(appointment => appointment.Request)
            .Include(appointment => appointment.Patient)
            .Include(appointment => appointment.Doctor)
            .Include(appointment => appointment.Specialty)
            .Include(appointment => appointment.Secretary)
            .ToListAsync(cancellationToken);

        public async Task<Appointment?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default)
        => await _dbSet
            .Include(appointment => appointment.Request)
            .Include(appointment => appointment.Patient)
            .Include(appointment => appointment.Doctor)
            .Include(appointment => appointment.Specialty)
            .Include(appointment => appointment.Secretary)
            .FirstOrDefaultAsync(appointment => appointment.Id == id, cancellationToken);
    }
}
