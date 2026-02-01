namespace AppointmentScheduler.Infraestructure.Data.Configurations;

public class SecretaryConfiguration : IEntityTypeConfiguration<Secretary>
{
    public void Configure (EntityTypeBuilder<Secretary> builder)
    {
        builder.ToTable("Secretaries");

        builder.HasKey(secretary => secretary.Id);

        builder.Property(secretary => secretary.Name).HasMaxLength(200).IsRequired();
        builder.Property(secretary => secretary.Cpf).HasMaxLength(11).IsFixedLength().IsUnicode(false).IsRequired();
        builder.Property(secretary => secretary.PhoneNumber).HasMaxLength(20).IsRequired();
        builder.Property(secretary => secretary.Email).HasMaxLength(200).IsRequired();
        builder.Property(secretary => secretary.HiringDate).IsRequired();
        builder.Property(secretary => secretary.Active).IsRequired().HasDefaultValue(true);

        builder.HasMany(secretary => secretary.Appointments).WithOne(appointment => appointment.Secretary)
            .HasForeignKey(appointment => appointment.SecretaryId).OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(secretary => secretary.ProcessedRequests).WithOne(request => request.ProcessedBySecretary)
            .HasForeignKey(request => request.ProcessedBySecretaryId).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(secretary => secretary.Cpf).IsUnique();
        builder.HasIndex(secretary => secretary.PhoneNumber).IsUnique();
        builder.HasIndex(secretary => secretary.Email).IsUnique();
    }
}