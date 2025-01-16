using AttendanceEpiisBk.Modules.Attendance.Domain.Entity;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AttendanceEpiisBk.Configuration.Context.EntityConfigurations;

public class AttendanceEntityConfiguration : IEntityTypeConfiguration<AttendanceEntity>
{
        public void Configure(EntityTypeBuilder<AttendanceEntity> builder)
        {
            builder.ToTable("Attendance");
            builder.HasKey(a => a.IdAttendance);

            builder.Property(a => a.Date);
            builder.Property(a => a.DepartureDate);
            builder.Property(a => a.IsLate);
            builder.Property(a => a.IsPresent);

            builder.HasOne(a => a.Teacher)
                .WithMany(t => t.Attendances)
                .HasForeignKey(a => a.TeacherId)
                .OnDelete(DeleteBehavior.Cascade).IsRequired(false);
            
            builder.HasOne(a => a.Student)
                .WithMany(s => s.Attendances)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Cascade).IsRequired(false);

            builder.HasOne(a => a.Event)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.EventId)
                .OnDelete(DeleteBehavior.Cascade).IsRequired(false);
            
            builder.HasOne(a => a.Guest)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.GuestId)
                .OnDelete(DeleteBehavior.Cascade).IsRequired(false);
        }
    
}