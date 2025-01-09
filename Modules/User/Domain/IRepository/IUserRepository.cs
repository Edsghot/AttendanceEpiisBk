using AttendanceEpiisBk.Configuration.Context.Repository;
using AttendanceEpiisBk.Modules.User.Domain.Entity;

namespace AttendanceEpiisBk.Modules.User.Domain.IRepository;

public interface IUserRepository : IBaseRepository
{
    Task<IEnumerable<UserEntity>> GetAllUserAsync();
}