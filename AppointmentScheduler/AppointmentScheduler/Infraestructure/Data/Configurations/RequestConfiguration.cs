using AppointmentScheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentScheduler.Infraestructure.Data.Configurations;

public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.ToTable("Requests");

        builder.HasKey(request => request.Id);
        builder.Property(request => request.Id).ValueGeneratedOnAdd();

        builder.Property(request => request.Status).HasConversion<string>().IsRequired();
        builder.Property(request => request.Type).HasConversion<string>().IsRequired();
    }
}