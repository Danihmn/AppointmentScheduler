using AppointmentScheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentScheduler.Infraestructure.Data.Configurations;

public class SecretaryConfiguration : IEntityTypeConfiguration<Secretary>
{
    public void Configure(EntityTypeBuilder<Secretary> builder)
    {
        builder.ToTable("Secretaries");

        builder.HasKey(secretary => secretary.Id);
        builder.Property(secretary => secretary.Id).ValueGeneratedOnAdd();

        builder.Property(secretary => secretary.Name).HasMaxLength(200).IsRequired();
        builder.Property(secretary => secretary.Cpf).HasMaxLength(11).IsRequired();
        builder.Property(secretary => secretary.PhoneNumber).HasMaxLength(11).IsRequired();
        builder.Property(secretary => secretary.Email).HasMaxLength(200).IsRequired();
        builder.Property(secretary => secretary.CreatedAt).HasDefaultValueSql("GETDATE()").IsRequired();
        builder.Property(secretary => secretary.Active).HasDefaultValue(true).IsRequired();
    }
}