using AppointmentScheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentScheduler.Infraestructure.Data.Configurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("Appointments");

        builder.HasKey(appointment => appointment.Id);
        builder.Property(appointment => appointment.Id).ValueGeneratedOnAdd();

        builder.Property(appointment => appointment.Date).HasDefaultValueSql("GETDATE()").IsRequired();
        builder.Property(appointment => appointment.Status).HasConversion<string>().IsRequired();
        builder.Property(appointment => appointment.Patient).IsRequired();
        builder.Property(appointment => appointment.Doctor).IsRequired();
        builder.Property(appointment => appointment.Specialty).IsRequired();
        builder.Property(appointment => appointment.Notes).HasMaxLength(250);
        builder.Property(appointment => appointment.Secretary).IsRequired();

        builder.HasOne(appointment => appointment.Patient).WithMany(patient => patient.Appointments)
            .HasForeignKey(appointment => appointment.Id);
        builder.HasOne(appointment => appointment.Doctor);
        builder.HasOne(appointment => appointment.Specialty);
        builder.HasOne(appointment => appointment.Secretary);
    }
}