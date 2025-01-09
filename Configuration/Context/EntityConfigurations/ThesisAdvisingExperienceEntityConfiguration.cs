using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

namespace AttendanceEpiisBk.Configuration.Context.EntityConfigurations;

public class ThesisAdvisingExperienceEntityConfiguration : IEntityTypeConfiguration<ThesisAdvisingExperienceEntity>
{
    public void Configure(EntityTypeBuilder<ThesisAdvisingExperienceEntity> builder)
    {
        builder.ToTable("ThesisAdvisingExperience");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.University)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(t => t.Thesis)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(t => t.ThesisStudent)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(t => t.Repository)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(t => t.ThesisAcceptanceDate)
            .IsRequired();

        builder.HasOne(t => t.Teacher)
            .WithMany(t => t.ThesisAdvisingExperiences)
            .HasForeignKey(t => t.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}