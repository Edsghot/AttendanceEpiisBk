using AttendanceEpiisBk.Configuration.Context;
using AttendanceEpiisBk.Configuration.Context.Repository;
using AttendanceEpiisBk.Modules.Event.Domain.IRepository;
using AttendanceEpiisBk.Modules.Student.Domain.IRepository;
using AttendanceEpiisBk.Modules.Teacher.Domain.IRepository;

namespace AttendanceEpiisBk.Modules.Event.Infraestructure.Repository;

public class EventRepository : BaseRepository<MySqlContext>, IEventRepository
{
    public EventRepository(MySqlContext context) : base(context)
    {
    }
}