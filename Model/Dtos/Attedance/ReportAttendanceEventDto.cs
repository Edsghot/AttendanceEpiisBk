using AttendanceEpiisBk.Model.Dtos.Event;
using AttendanceEpiisBk.Model.Dtos.Guest;
using AttendanceEpiisBk.Model.Dtos.Student;
using AttendanceEpiisBk.Model.Dtos.Teacher;

namespace AttendanceEpiisBk.Model.Dtos.Attedance;

public class ReportAttendanceEventDto
{
    public EventAttendanceDto? Event { get; set; }
    public List<StudentAttendanceDto> ListStudentAttendance{ get; set; }
    public List<TeacherAttendanceDto>? ListTeacherAttendance { get; set; }        
    public List<GuestAttendanceDto>? ListGuestAttendancee { get; set; }        

}