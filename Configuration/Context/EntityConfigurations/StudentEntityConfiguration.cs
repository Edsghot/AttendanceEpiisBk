using AttendanceEpiisBk.Modules.Student.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceEpiisBk.Configuration.Context.EntityConfigurations;

public class StudentEntityConfiguration : IEntityTypeConfiguration<StudentEntity>
{
    public void Configure(EntityTypeBuilder<StudentEntity> builder)
    {
        builder.ToTable("Student");
        builder.HasKey(s => s.IdStudent);

        builder.Property(s => s.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(s => s.LastName)
            .HasMaxLength(300)
            .IsRequired(false);

        builder.Property(s => s.Mail)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(s => s.Phone)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(s => s.Gender);

        builder.Property(s => s.Dni)
            .IsRequired();

        builder.HasMany(s => s.Attendances)
            .WithOne(a => a.Student)
            .HasForeignKey(a => a.StudentId)
            .OnDelete(DeleteBehavior.Cascade).IsRequired(false);;
    }
}