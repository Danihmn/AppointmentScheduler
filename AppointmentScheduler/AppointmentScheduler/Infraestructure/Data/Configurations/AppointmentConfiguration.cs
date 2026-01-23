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

        builder.Property(appointment => appointment.Date).IsRequired();
        builder.Property(appointment => appointment.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(50);
        builder.Property(appointment => appointment.Notes).HasMaxLength(250);

        builder.HasOne(appointment => appointment.Request)
            .WithOne(request => request.ResultingAppointment)
            .HasForeignKey<Appointment>(appointment => appointment.RequestId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(appointment => appointment.Patient)
            .WithMany(patient => patient.Appointments)
            .HasForeignKey(appointment => appointment.PatientId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(appointment => appointment.Doctor)
            .WithMany(doctor => doctor.Appointments)
            .HasForeignKey(appointment => appointment.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(appointment => appointment.Specialty)
            .WithMany()
            .HasForeignKey(appointment => appointment.SpecialtyId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(appointment => appointment.Secretary)
            .WithMany()
            .HasForeignKey(appointment => appointment.SecretaryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(appointment => new { appointment.DoctorId, appointment.Date })
            .IsUnique();
        builder.HasIndex(appointment => appointment.RequestId)
            .IsUnique();
        builder.HasIndex(appointment => appointment.PatientId);
        builder.HasIndex(appointment => appointment.Date);
    }
}