using AppointmentScheduler.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentScheduler.Infraestructure.Data.Configurations;

public class WaitingListConfiguration : IEntityTypeConfiguration<WaitingList>
{
    public void Configure(EntityTypeBuilder<WaitingList> builder)
    {
        builder.ToTable("WaitingLists");

        builder.HasKey(waitingList => waitingList.Id);
        builder.Property(waitingList => waitingList.Id).ValueGeneratedOnAdd();
        builder.Property(waitingList => waitingList.Requests).IsRequired();

        builder.HasMany(waitingList => waitingList.Requests);
    }
}