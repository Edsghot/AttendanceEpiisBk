using AttendanceEpiisBk.Configuration.Context;
using AttendanceEpiisBk.Configuration.Context.Repository;
using AttendanceEpiisBk.Modules.Teacher.Domain.IRepository;

namespace AttendanceEpiisBk.Modules.Teacher.Infraestructure.Repository;

public class TeacherRepository : BaseRepository<MySqlContext>, ITeacherRepository
{
    public TeacherRepository(MySqlContext context) : base(context)
    {
    }
}