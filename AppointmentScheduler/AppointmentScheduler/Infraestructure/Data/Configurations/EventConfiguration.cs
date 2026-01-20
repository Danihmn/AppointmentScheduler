using AppointmentScheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentScheduler.Infraestructure.Data.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");

        // "event" is a reserved word
        builder.HasKey(eventValue => eventValue.Id);
        builder.Property(eventValue => eventValue.Id).ValueGeneratedOnAdd();

        builder.Property(eventValue => eventValue.Category).HasConversion<string>().IsRequired();
        builder.Property(eventValue => eventValue.Date).IsRequired();
        builder.Property(eventValue => eventValue.Appointment).IsRequired();
        builder.Property(eventValue => eventValue.Notes).HasMaxLength(250);

        builder.HasOne(eventValue => eventValue.Appointment);
    }
}