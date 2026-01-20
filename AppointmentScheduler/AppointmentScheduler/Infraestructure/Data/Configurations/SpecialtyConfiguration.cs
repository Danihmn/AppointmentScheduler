using AppointmentScheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentScheduler.Infraestructure.Data.Configurations;

public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
{
    public void Configure(EntityTypeBuilder<Specialty> builder)
    {
        builder.ToTable("Specialties");

        builder.HasKey(specialty => specialty.Id);
        builder.Property(specialty => specialty.Id).ValueGeneratedOnAdd();

        builder.Property(specialty => specialty.Description).HasMaxLength(250).IsRequired();
    }
}