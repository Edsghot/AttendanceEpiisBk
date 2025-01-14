using AttendanceEpiisBk.Configuration.Context;
using AttendanceEpiisBk.Configuration.Context.Repository;
using AttendanceEpiisBk.Modules.Event.Domain.IRepository;
using AttendanceEpiisBk.Modules.Student.Domain.IRepository;
using AttendanceEpiisBk.Modules.Teacher.Domain.IRepository;

namespace AttendanceEpiisBk.Modules.Product.Infraestructure.Repository;

public class ProductRepository : BaseRepository<MySqlContext>, IEventRepository
{
    public ProductRepository(MySqlContext context) : base(context)
    {
    }
}