using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AttendanceEpiisBk.Modules.Research.Domain.Entity;

namespace AttendanceEpiisBk.Configuration.Context.EntityConfigurations;

public class ResearchProjectEntityConfiguration : IEntityTypeConfiguration<ResearchProjectEntity>
{
    public void Configure(EntityTypeBuilder<ResearchProjectEntity> builder)
    {
        builder.ToTable("ResearchProject");
        builder.HasKey(rp => rp.Id);

        builder.Property(rp => rp.Name)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(rp => rp.Description)
            .HasMaxLength(1000);

        builder.Property(rp => rp.Summary)
            .HasMaxLength(2000);

        builder.Property(rp => rp.Date)
            .IsRequired();

        builder.Property(rp => rp.Doi)
            .HasMaxLength(100);

        builder.Property(rp => rp.Authors)
            .HasMaxLength(500);

        builder.Property(rp => rp.Pdf)
            .HasMaxLength(500);

        builder.Property(rp => rp.Editor)
            .HasMaxLength(255);
    }
}