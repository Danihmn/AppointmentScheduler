namespace AppointmentScheduler.Infraestructure.Data;

public class ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<Secretary> Secretaries { get; set; }
    public DbSet<Specialty> Specialties { get; set; }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}