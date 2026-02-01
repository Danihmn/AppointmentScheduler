namespace AppointmentScheduler.Infraestructure.Data.Configurations;

public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
{
    public void Configure (EntityTypeBuilder<Specialty> builder)
    {
        builder.ToTable("Specialties");

        builder.HasKey(specialty => specialty.Id);

        builder.Property(specialty => specialty.Description).HasMaxLength(250).IsRequired();

        builder.HasMany(specialty => specialty.Requests).WithOne(request => request.Specialty)
            .HasForeignKey(request => request.SpecialtyId).OnDelete(DeleteBehavior.Restrict);
    }
}