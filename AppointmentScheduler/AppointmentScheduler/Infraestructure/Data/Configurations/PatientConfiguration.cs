namespace AppointmentScheduler.Infraestructure.Data.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure (EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patients");

        builder.HasKey(patient => patient.Id);

        builder.Property(patient => patient.Name).IsRequired().HasMaxLength(200);
        builder.Property(patient => patient.Cpf).IsRequired().HasMaxLength(11).IsFixedLength().IsUnicode(false);
        builder.Property(patient => patient.PhoneNumber).IsRequired().HasMaxLength(20).IsUnicode(false);
        builder.Property(patient => patient.Email).IsRequired().HasMaxLength(250);
        builder.Property(patient => patient.Gender).IsRequired().HasConversion<string>().HasMaxLength(20);
        builder.Property(patient => patient.Notes).HasMaxLength(500);

        builder.HasMany(patient => patient.Appointments).WithOne(appointment => appointment.Patient)
            .HasForeignKey(appointment => appointment.PatientId).OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(patient => patient.Requests).WithOne(request => request.Patient)
            .HasForeignKey(request => request.PatientId).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(patient => patient.Cpf).IsUnique();
        builder.HasIndex(patient => patient.Email).IsUnique();
        builder.HasIndex(patient => patient.Name);
    }
}