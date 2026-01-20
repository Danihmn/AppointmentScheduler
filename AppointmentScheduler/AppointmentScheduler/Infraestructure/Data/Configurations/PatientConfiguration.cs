using AppointmentScheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentScheduler.Infraestructure.Data.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patients");

        builder.HasKey(patient => patient.Id);
        builder.Property(patient => patient.Id).ValueGeneratedOnAdd();

        builder.Property(patient => patient.Name).HasMaxLength(200).IsRequired();
        builder.Property(patient => patient.Cpf).HasMaxLength(11).IsRequired();
        builder.Property(patient => patient.PhoneNumber).HasMaxLength(11).IsRequired();
        builder.Property(patient => patient.Email).HasMaxLength(250).IsRequired();
        builder.Property(patient => patient.Gender).HasConversion<string>().IsRequired();
        builder.Property(patient => patient.Notes).HasMaxLength(250);
        builder.Property(patient => patient.Appointments).HasDefaultValue(null);

        builder.HasMany(patient => patient.Appointments).WithOne(appointment => appointment.Patient)
            .HasForeignKey(appointment => appointment.Id);
    }
}