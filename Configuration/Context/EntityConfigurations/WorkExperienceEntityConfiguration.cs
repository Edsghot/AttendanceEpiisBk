using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

namespace AttendanceEpiisBk.Configuration.Context.EntityConfigurations;

public class WorkExperienceEntityConfiguration : IEntityTypeConfiguration<WorkExperienceEntity>
{
    public void Configure(EntityTypeBuilder<WorkExperienceEntity> builder)
    {
        builder.ToTable("WorkExperience");
        builder.HasKey(w => w.Id);

        builder.Property(w => w.CompanyName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(w => w.Position)
            .HasMaxLength(400)
            .IsRequired();

        builder.Property(w => w.JobIdi)
            .HasMaxLength(400)
            .IsRequired();

        builder.Property(w => w.StartDate)
            .IsRequired();

        builder.Property(w => w.EndDate)
            .IsRequired();

        builder.Property(w => w.JobDescription)
            .HasMaxLength(1000)
            .IsRequired(false);

        builder.Property(w => w.IsCurrent)
            .IsRequired();

        builder.HasOne(w => w.Teacher)
            .WithMany(t => t.WorkExperiences)
            .HasForeignKey(w => w.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}