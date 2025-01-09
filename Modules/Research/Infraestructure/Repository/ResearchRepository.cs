using AttendanceEpiisBk.Configuration.Context;
using AttendanceEpiisBk.Configuration.Context.Repository;
using AttendanceEpiisBk.Modules.Research.Domain.IRepository;
using AttendanceEpiisBk.Modules.Teacher.Domain.IRepository;

namespace AttendanceEpiisBk.Modules.Research.Infraestructure.Repository;

public class ResearchRepository : BaseRepository<MySqlContext>, IResearchRepository
{
    public ResearchRepository(MySqlContext context) : base(context)
    {
    }
}