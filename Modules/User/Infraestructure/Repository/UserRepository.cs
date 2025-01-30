using AttendanceEpiisBk.Configuration.Context;
using AttendanceEpiisBk.Configuration.Context.Repository;
using AttendanceEpiisBk.Modules.Event.Domain.IRepository;
using AttendanceEpiisBk.Modules.Student.Domain.IRepository;
using AttendanceEpiisBk.Modules.Teacher.Domain.IRepository;
using AttendanceEpiisBk.Modules.User.Domain.IRepository;

namespace AttendanceEpiisBk.Modules.User.Infraestructure.Repository;

public class UserRepository : BaseRepository<MySqlContext>, IUserRepository
{
    public UserRepository(MySqlContext context) : base(context)
    {
    }
}