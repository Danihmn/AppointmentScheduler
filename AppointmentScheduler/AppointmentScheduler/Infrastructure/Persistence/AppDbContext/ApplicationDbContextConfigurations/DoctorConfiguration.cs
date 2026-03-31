namespace AppointmentScheduler.Infrastructure.Persistence.AppDbContext.ApplicationDbContextConfigurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure (EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctors");

        builder.HasKey(doctor => doctor.Id);

        builder.Property(doctor => doctor.Name).IsRequired().HasMaxLength(200);
        builder.Property(doctor => doctor.Crm).IsRequired().HasMaxLength(15).IsUnicode(false);
        builder.Property(doctor => doctor.PhoneNumber).IsRequired().HasMaxLength(20).IsUnicode(false);
        builder.Property(doctor => doctor.Email).IsRequired().HasMaxLength(254);
        builder.Property(doctor => doctor.HiringDate).IsRequired();
        builder.Property(doctor => doctor.Active).IsRequired().HasDefaultValue(true);

        builder.HasOne(doctor => doctor.Specialty).WithMany(specialty => specialty.Doctors).HasForeignKey(doctor => doctor.SpecialtyId).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(doctor => doctor.Crm).IsUnique();
        builder.HasIndex(doctor => doctor.Email).IsUnique();
        builder.HasIndex(doctor => doctor.SpecialtyId);
        builder.HasIndex(doctor => doctor.Active);
        builder.HasIndex(doctor => doctor.Name);
    }
}