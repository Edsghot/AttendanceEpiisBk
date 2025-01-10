using Microsoft.EntityFrameworkCore;
using AttendanceEpiisBk.Configuration.Context.EntityConfigurations;
using AttendanceEpiisBk.Modules.Attendance.Domain.Entity;
using AttendanceEpiisBk.Modules.Event.Domain.Entity;
using AttendanceEpiisBk.Modules.Student.Domain.Entity;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

namespace AttendanceEpiisBk.Configuration.Context;

public class MySqlContext : DbContext
{
    public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
    {
    }
    
    public DbSet<EventEntity> Events { get; set; }
    public DbSet<AttendanceEntity> Attendances { get; set; }
    public DbSet<TeacherEntity> Teachers { get; set; }
    public DbSet<StudentEntity> Students { get; set; }
    public DbSet<GuestEntity> Guests { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString =
            "Server=jhedgost.com;Database=dbjhfjuv_AttendanceEpiisBk;User=dbjhfjuv_edsghot;Password=Repro321.;";

        optionsBuilder.UseMySql(
            connectionString,
            new MySqlServerVersion(new Version(8, 0, 21))
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TeacherEntityConfiguration());
        modelBuilder.ApplyConfiguration(new AttendanceEntityConfiguration());
        modelBuilder.ApplyConfiguration(new EventEntityConfiguration());
        modelBuilder.ApplyConfiguration(new StudentEntityConfiguration());    
        modelBuilder.ApplyConfiguration(new GuestEntityConfiguration());   
    }
}