
using AttendanceEpiisBk.Model.Dtos.Attedance;
using AttendanceEpiisBk.Model.Dtos.Event;

namespace AttendanceEpiisBk.Modules.Attendance.Application.Port;

public interface IAttendanceInputPort
{
    Task GetAllAsync();
    Task GetById(int id);
    Task AddParticipant(InsertParticipantDto data);
    Task TakeAttendance(InsertAttendanceDto data);
    Task ReportByEventId(int id);
}