namespace AppointmentScheduler.Infrastructure.Persistence.Repositories.Implementation
{
    public class AppointmentRepository (ApplicationDbContext context)
        : Repository<Appointment>(context), IAppointmentRepository
    {
        private readonly DbSet<Appointment> _dbSet = context.Set<Appointment>();

        public async Task<IEnumerable<Appointment>> GetAllWithDetailAsync (CancellationToken cancellationToken = default)
        => await _dbSet
            .Include(appointment => appointment.Request)
            .Include(appointment => appointment.Doctor)
            .ToListAsync(cancellationToken);

        public async Task<Appointment?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default)
        => await _dbSet
            .Include(appointment => appointment.Request)
            .Include(appointment => appointment.Doctor)
            .FirstOrDefaultAsync(appointment => appointment.Id == id, cancellationToken);

        public async Task<bool> HasConflictAsync (int doctorId, DateTime date, CancellationToken cancellationToken = default)
        => await _dbSet
            .AnyAsync(appointment => appointment.DoctorId == doctorId
            && appointment.Date == date
            && appointment.Status == EAppointmentStatus.Scheduled, cancellationToken);
    }
}
