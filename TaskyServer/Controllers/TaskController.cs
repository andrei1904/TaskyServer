using Microsoft.AspNetCore.Mvc;
using TS.Business.Interfaces;

namespace TaskyServer.Controllers;

[ApiController]
[Route("api/tasks")]
public class TaskController : ControllerBase
{
    private readonly IUserService _userService;

    public TaskController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost]
    [Route("")]
    public async Task<IActionResult> Add([FromBody] UserCreationViewModel userCreationViewModel)
    {
        var addedUser = await _userService.AddAsync(userCreationViewModel.ToEntity());
        if (addedUser == null) return BadRequest("Username already exists!");

        return Ok(addedUser.ToViewModel());
    }
}