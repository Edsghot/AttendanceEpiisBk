using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

namespace AttendanceEpiisBk.Configuration.Context.EntityConfigurations;

public class TeachingExperienceEntityConfiguration : IEntityTypeConfiguration<TeachingExperienceEntity>
{
    public void Configure(EntityTypeBuilder<TeachingExperienceEntity> builder)
    {
        builder.ToTable("TeachingExperience");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Institution)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.InstitutionType)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.TeacherType)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.JobDescription)
            .HasMaxLength(1000)
            .IsRequired();

        builder.Property(t => t.StartDate)
            .IsRequired();

        builder.Property(t => t.EndDate)
            .IsRequired();

        builder.HasOne(t => t.Teacher)
            .WithMany(t => t.TeachingExperiences)
            .HasForeignKey(t => t.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}