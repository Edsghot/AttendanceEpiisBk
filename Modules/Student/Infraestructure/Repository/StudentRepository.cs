using AttendanceEpiisBk.Configuration.Context;
using AttendanceEpiisBk.Configuration.Context.Repository;
using AttendanceEpiisBk.Modules.Student.Domain.IRepository;
using AttendanceEpiisBk.Modules.Teacher.Domain.IRepository;

namespace AttendanceEpiisBk.Modules.Student.Infraestructure.Repository;

public class StudentRepository : BaseRepository<MySqlContext>, IStudentRepository
{
    public StudentRepository(MySqlContext context) : base(context)
    {
    }
}