using AttendanceEpiisBk.Model.Dtos.User;
using AttendanceEpiisBk.Modules.Attendance.Application.Port;
using AttendanceEpiisBk.Modules.user.Application.Port;
using AttendanceEpiisBk.Modules.User.Application.Port;
using AttendanceEpiisBk.Modules.User.Domain.Entity;
using AttendanceEpiisBk.Modules.User.Domain.IRepository;
using Mapster;
using BCrypt.Net;

namespace AttendanceEpiisBk.Modules.User.Application.Adapter;

public class UserAdapter : IUserInputPort
{
    private readonly IUserOutPort _userOutPort;
    private readonly IUserRepository _userRepository;

    public UserAdapter(IUserRepository repository, IUserOutPort userOutPort)
    {
        _userRepository = repository;
        _userOutPort = userOutPort;
    }

    public async Task GetById(int id)
    {
        var user = await _userRepository.GetAsync<UserEntity>(x => x.IdUser == id);
        if (user == null)
        {
            _userOutPort.NotFound("No se encontró el usuario");
            return;
        }

        var userDto = user.Adapt<UserDto>();
        _userOutPort.GetById(userDto);
    }

    public async Task GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync<UserEntity>();
        var userEntities = users.ToList();
        if (!userEntities.Any())
        {
            _userOutPort.NotFound("No se encontraron usuarios");
            return;
        }

        var userDtos = users.Adapt<List<UserDto>>();
        _userOutPort.GetAllAsync(userDtos);
    }

    public async Task Add(UserDto data)
    {
        var userEntity = data.Adapt<UserEntity>();
        userEntity.Password = BCrypt.Net.BCrypt.HashPassword(data.Password);
        await _userRepository.AddAsync(userEntity);
        await _userRepository.SaveChangesAsync();
        _userOutPort.Success(userEntity, "Usuario agregado exitosamente.");
    }

    public async Task Update(UserDto data)
    {
        var existingUser = await _userRepository.GetAsync<UserEntity>(x => x.IdUser == data.IdUser);
        if (existingUser == null)
        {
            _userOutPort.Error("No se encontró el usuario que quieres actualizar");
            return;
        }

        existingUser.NameUser = data.NameUser;
        existingUser.Mail = data.Mail;
        existingUser.Dni = data.Dni;
        existingUser.Gender = data.Gender;
        existingUser.Phone = data.Phone;
        existingUser.LastName = data.LastName;
        existingUser.Name = data.Name;
        
        if (!string.IsNullOrEmpty(data.Password))
        {
            existingUser.Password = BCrypt.Net.BCrypt.HashPassword(data.Password);
        }
        await _userRepository.UpdateAsync(existingUser);
        await _userRepository.SaveChangesAsync();
        _userOutPort.Success(existingUser, "Usuario actualizado exitosamente.");
    }

    public async Task Delete(int id)
    {
        var user = await _userRepository.GetAsync<UserEntity>(x => x.IdUser == id);
        if (user == null)
        {
            _userOutPort.Error("No se encontró el usuario que quieres eliminar");
            return;
        }

        await _userRepository.DeleteAsync(user);
        await _userRepository.SaveChangesAsync();
        _userOutPort.Success(user, "Usuario eliminado exitosamente.");
    }

    public async Task Login(string username, string password)
    {
        var user = await _userRepository.GetAsync<UserEntity>(x => x.NameUser == username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
        {
            _userOutPort.Error("Credenciales incorrectas");
            return;
        }

        var userDto = user.Adapt<UserDto>();
        _userOutPort.Success(userDto, "Inicio de sesión exitoso.");
    }
}