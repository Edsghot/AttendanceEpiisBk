using AttendanceEpiisBk.Modules.Event.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceEpiisBk.Configuration.Context.EntityConfigurations;

public class GuestEntityConfiguration : IEntityTypeConfiguration<GuestEntity>
{
    public void Configure(EntityTypeBuilder<GuestEntity> builder)
    {
        builder.ToTable("Guest");

        builder.HasKey(g => g.IdGuest);

        builder.Property(g => g.FirstName)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(g => g.LastName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(g => g.Mail)
            .IsRequired()
            .HasMaxLength(300);

        builder.HasMany(g => g.Attendances)
            .WithOne()
            .HasForeignKey("GuestId").IsRequired(false);        
    }
}