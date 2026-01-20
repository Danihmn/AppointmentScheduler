using AppointmentScheduler.Domain.Entities;
using AppointmentScheduler.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentScheduler.Infraestructure.Data.Configurations;

public class RequestConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.ToTable("Requests");

        builder.HasKey(request => request.Id);

        builder.Property(request => request.Status).IsRequired().HasConversion<string>().HasMaxLength(50)
            .HasDefaultValue(ERequestStatus.Pending);
        builder.Property(request => request.Type).IsRequired().HasConversion<string>().HasMaxLength(50);
        builder.Property(request => request.DesiredDate).IsRequired();
        builder.Property(request => request.Description).IsRequired().HasMaxLength(1000);
        builder.Property(request => request.Notes).HasMaxLength(500);
        builder.Property(request => request.Priority).IsRequired().HasDefaultValue(3);

        builder.HasOne(request => request.Patient).WithMany(patient => patient.Requests)
            .HasForeignKey(request => request.PatientId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(request => request.Specialty).WithMany(specialty => specialty.Requests)
            .HasForeignKey(request => request.SpecialtyId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(request => request.ProcessedBySecretary).WithMany()
            .HasForeignKey(request => request.ProcessedBySecretaryId).OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(request => request.ResultingAppointment).WithOne()
            .HasForeignKey<Request>(r => r.ResultingAppointmentId).OnDelete(DeleteBehavior.SetNull);

        builder.HasIndex(request => request.PatientId);
        builder.HasIndex(request => request.SpecialtyId);
        builder.HasIndex(request => request.Status);
        builder.HasIndex(request => request.Priority);
        builder.HasIndex(request => request.DesiredDate);
        builder.HasIndex(request => new { request.Status, request.Priority, request.DesiredDate });
    }
}