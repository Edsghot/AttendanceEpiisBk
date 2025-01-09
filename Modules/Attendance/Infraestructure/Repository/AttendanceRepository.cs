using AttendanceEpiisBk.Configuration.Context;
using AttendanceEpiisBk.Configuration.Context.Repository;
using AttendanceEpiisBk.Modules.Event.Domain.IRepository;
using AttendanceEpiisBk.Modules.Student.Domain.IRepository;
using AttendanceEpiisBk.Modules.Teacher.Domain.IRepository;

namespace AttendanceEpiisBk.Modules.Attendance.Infraestructure.Repository;

public class AttendanceRepository : BaseRepository<MySqlContext>, IAttendanceRepository
{
    public AttendanceRepository(MySqlContext context) : base(context)
    {
    }
}