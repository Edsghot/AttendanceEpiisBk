using Microsoft.EntityFrameworkCore;
using AttendanceEpiisBk.Configuration.Context;
using AttendanceEpiisBk.Configuration.Context.Repository;
using AttendanceEpiisBk.Configuration.DataBase;
using AttendanceEpiisBk.Modules.User.Domain.Entity;
using AttendanceEpiisBk.Modules.User.Domain.IRepository;

namespace AttendanceEpiisBk.Modules.User.Infraestructure.Repository;

public class UserRepository : BaseRepository<MySqlContext>, IUserRepository
{
    public UserRepository(MySqlContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<UserEntity>> GetAllUserAsync()
    {
        return await _context.Users.ToListAsync();
    }
}