using AttendanceEpiisBk.Modules.Event.Domain.Entity;
using AttendanceEpiisBk.Modules.Student.Domain.Entity;
using AttendanceEpiisBk.Modules.Teacher.Domain.Entity;

namespace AttendanceEpiisBk.Modules.Attendance.Domain.Entity;

public record AttendanceEntity
{
    public int IdAttendance { get; set; }
    public DateTime Date { get; set; }
    public bool IsPresent { get; set; }
    public int EventId { get; set; }
    public int? StudentId { get; set; }
    
    public int? TeacherId { get; set; }
    public int? GuestId { get; set; }
    
    public TeacherEntity Teacher { get; set; }
    public StudentEntity Student { get; set; }
    public EventEntity Event { get; set; } 
    public GuestEntity Guest { get; set; } 
}