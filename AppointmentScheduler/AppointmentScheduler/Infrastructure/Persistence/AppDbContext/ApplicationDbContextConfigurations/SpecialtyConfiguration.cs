namespace AppointmentScheduler.Infrastructure.Persistence.AppDbContext.ApplicationDbContextConfigurations;

public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
{
    public void Configure (EntityTypeBuilder<Specialty> builder)
    {
        builder.ToTable("Specialties");

        builder.HasKey(specialty => specialty.Id);

        builder.Property(specialty => specialty.Description).HasMaxLength(250).IsRequired();
        builder.Property(specialty => specialty.IsActive).IsRequired().HasDefaultValue(true);

        builder.HasIndex(specialty => specialty.Description).IsUnique();
        builder.HasIndex(specialty => specialty.IsActive);
    }
}