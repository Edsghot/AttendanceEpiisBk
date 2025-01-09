using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

namespace AttendanceEpiisBk.Configuration.Context.EntityConfigurations;

public class TeacherEntityConfiguration : IEntityTypeConfiguration<TeacherEntity>
{
    public void Configure(EntityTypeBuilder<TeacherEntity> builder)
    {
        builder.ToTable("Teacher");
        builder.HasKey(t => t.IdTeacher);

        builder.Property(t => t.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.LastName)
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(t => t.Mail)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.Password)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.Phone)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.Gender)
            .IsRequired();

        builder.Property(t => t.BirthDate)
            .IsRequired();

        builder.Property(t => t.RegistrationCode)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.Description)
            .HasMaxLength(900);

        builder.Property(t => t.Image)
            .HasMaxLength(500);

        builder.Property(t => t.Facebook)
            .HasMaxLength(200);

        builder.Property(t => t.Instagram)
            .HasMaxLength(200);

        builder.Property(t => t.LinkedIn)
            .HasMaxLength(200);

        builder.Property(t => t.Position);

        builder.HasMany(t => t.WorkExperiences)
            .WithOne(w => w.Teacher)
            .HasForeignKey(w => w.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.TeachingExperiences)
            .WithOne(te => te.Teacher)
            .HasForeignKey(te => te.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.ThesisAdvisingExperiences)
            .WithOne(tae => tae.Teacher)
            .HasForeignKey(tae => tae.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}