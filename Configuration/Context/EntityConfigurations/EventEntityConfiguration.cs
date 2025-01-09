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
            .IsRequired();

        builder.Property(e => e.Date)
            .IsRequired();

        builder.Property(e => e.Location)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(e => e.IsPrivate)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(1000);

        builder.Property(e => e.Duration)
            .IsRequired();
    }
}