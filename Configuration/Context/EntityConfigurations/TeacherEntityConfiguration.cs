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
            .IsRequired(false);

        builder.Property(t => t.Mail)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(t => t.Password)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(t => t.Phone)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(t => t.Gender);

        builder.Property(t => t.BirthDate);
        builder.Property(t => t.Dni)
            .IsRequired(false);
        builder.HasMany(t => t.Attendances)
            .WithOne(a => a.Teacher)
            .HasForeignKey(a => a.TeacherId)
            .OnDelete(DeleteBehavior.Cascade).IsRequired(false);;

    }
}