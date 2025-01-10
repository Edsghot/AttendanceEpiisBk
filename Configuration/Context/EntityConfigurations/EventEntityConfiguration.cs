using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AttendanceEpiisBk.Modules.Event.Domain.Entity;

public class EventEntityConfiguration : IEntityTypeConfiguration<EventEntity>
{
    public void Configure(EntityTypeBuilder<EventEntity> builder)
    {
        builder.ToTable("Event");
        builder.HasKey(e => e.IdEvent);

        builder.Property(e => e.Name)
            .HasMaxLength(200)
            .IsRequired(false);

        builder.Property(e => e.Date);

        builder.Property(e => e.StartTime);

        builder.Property(e => e.EndTime);

        builder.Property(e => e.Location)
            .HasMaxLength(300)
            .IsRequired(false);

        builder.Property(e => e.IsPrivate);

        builder.Property(e => e.Description)
            .HasMaxLength(1000)
            .IsRequired(false);

        builder.Property(e => e.EventTypeId);

        builder.HasMany(e => e.Attendances)
            .WithOne(a => a.Event)
            .HasForeignKey(a => a.EventId)
            .OnDelete(DeleteBehavior.Cascade).IsRequired(false);

    }
}