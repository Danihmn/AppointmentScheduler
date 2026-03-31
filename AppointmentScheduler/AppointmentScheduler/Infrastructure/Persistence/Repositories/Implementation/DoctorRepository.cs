using AppointmentScheduler.Infrastructure.Persistence.AppDbContext;
using AppointmentScheduler.Infrastructure.Persistence.Repositories.Contract;
using AppointmentScheduler.Infrastructure.Persistence.Repositories.Implementation.Generic;

namespace AppointmentScheduler.Infrastructure.Persistence.Repositories.Implementation
{
    public class DoctorRepository (AppDbContext.ApplicationDbContext context)
        : Repository<Doctor>(context), IDoctorRepository
    {
        private readonly DbSet<Doctor> _dbSet = context.Set<Doctor>();

        public async Task<IEnumerable<Doctor>> GetAllWithDetailAsync (CancellationToken cancellationToken = default)
        => await _dbSet
            .Include(doctor => (doctor).Specialty)
            .Include(doctor => (doctor).Appointments)
            .ToListAsync(cancellationToken);

        public async Task<Doctor?> GetByIdWithDetailsAsync (int id, CancellationToken cancellationToken = default)
        => await _dbSet
            .Include(doctor => (doctor).Specialty)
            .Include(doctor => (doctor).Appointments)
            .FirstOrDefaultAsync(doctor => doctor.Id == id, cancellationToken);
    }
}
