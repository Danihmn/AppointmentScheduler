using AppointmentScheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentScheduler.Infraestructure.Data.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctors");

        builder.HasKey(doctor => doctor.Id);
        builder.Property(doctor => doctor.Id).ValueGeneratedOnAdd();

        builder.Property(doctor => doctor.Name).HasMaxLength(200).IsRequired();
        builder.Property(doctor => doctor.Crm).HasMaxLength(6).IsRequired();
        builder.Property(doctor => doctor.Specialty).IsRequired();
        builder.Property(doctor => doctor.PhoneNumber).IsRequired();
        builder.Property(doctor => doctor.Email).IsRequired();
        builder.Property(doctor => doctor.HiringDate).IsRequired();
        builder.Property(doctor => doctor.Active).IsRequired();
        builder.Property(doctor => doctor.Schedules).IsRequired();

        builder.HasOne(doctor => doctor.Specialty);
        builder.HasMany(doctor => doctor.Schedules).WithOne(schedule => schedule.Doctor)
            .HasForeignKey(schedule => schedule.Id);
    }
}