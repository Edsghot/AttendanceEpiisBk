using AttendanceEpiisBk.Model.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using AttendanceEpiisBk.Modules.User.Application.Port;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await _userInputPort.GetAllUsersAsync();
        var response = _userOutPort.GetResponse;

        return Ok(response);
    }

    // GET api/<ResearchController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ResearchController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ResearchController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ResearchController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}