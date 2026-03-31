namespace AppointmentScheduler.Infrastructure.Persistence.AppDbContext.ApplicationDbContextConfigurations;

public class SecretaryConfiguration : IEntityTypeConfiguration<Secretary>
{
    public void Configure (EntityTypeBuilder<Secretary> builder)
    {
        builder.ToTable("Secretaries");

        builder.HasKey(secretary => secretary.Id);

        builder.Property(secretary => secretary.Username).HasMaxLength(40).IsRequired();
        builder.Property(secretary => secretary.HashedPassword).HasMaxLength(200).IsRequired();
        builder.Property(secretary => secretary.Name).HasMaxLength(200).IsRequired();
        builder.Property(secretary => secretary.Cpf).HasMaxLength(11).IsFixedLength().IsUnicode(false).IsRequired();
        builder.Property(secretary => secretary.PhoneNumber).HasMaxLength(20).IsUnicode(false).IsRequired();
        builder.Property(secretary => secretary.Email).HasMaxLength(254).IsRequired();
        builder.Property(secretary => secretary.HiringDate).IsRequired();
        builder.Property(secretary => secretary.Active).IsRequired().HasDefaultValue(true);
        builder.Property(secretary => secretary.Role).HasConversion<string>().HasMaxLength(20);

        builder.HasIndex(secretary => secretary.Username).IsUnique();
        builder.HasIndex(secretary => secretary.Cpf).IsUnique();
        builder.HasIndex(secretary => secretary.PhoneNumber).IsUnique();
        builder.HasIndex(secretary => secretary.Email).IsUnique();
    }
}