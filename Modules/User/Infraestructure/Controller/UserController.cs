using AttendanceEpiisBk.Model.Dtos.User;
using AttendanceEpiisBk.Modules.user.Application.Port;
using Microsoft.AspNetCore.Mvc;
using AttendanceEpiisBk.Modules.User.Application.Port;

namespace AttendanceEpiisBk.Modules.User.Infraestructure.Controller;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserInputPort _userInputPort;
    private readonly IUserOutPort _userOutPort;

    public UserController(IUserInputPort userInputPort, IUserOutPort userOutPort)
    {
        _userInputPort = userInputPort;
        _userOutPort = userOutPort;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        await _userInputPort.GetAllAsync();
        var response = _userOutPort.GetResponse;

        return Ok(response);
    }

    [HttpGet("GetById/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        await _userInputPort.GetById(id);
        var response = _userOutPort.GetResponse;

        return Ok(response);
    }

    [HttpPost("AddUser")]
    public async Task<IActionResult> AddUser([FromBody] UserDto userDto)
    {
        await _userInputPort.Add(userDto);
        return Ok(_userOutPort.GetResponse);
    }

    [HttpPut("UpdateUser")]
    public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
    {
        await _userInputPort.Update(userDto);
        return Ok(_userOutPort.GetResponse);
    }

    [HttpDelete("DeleteUser/{id:int}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        await _userInputPort.Delete(id);
        return Ok(_userOutPort.GetResponse);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        await _userInputPort.Login(loginDto.Username, loginDto.Password);
        return Ok(_userOutPort.GetResponse);
    }
}