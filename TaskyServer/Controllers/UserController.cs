using Microsoft.AspNetCore.Mvc;
using TaskyServer.Filters;
using TS.Business.Interfaces;
using TS.Model.Mappers;
using TS.Model.ViewModels;

namespace TaskyServer.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [Route("{id:int}")]
    [AuthorizationFilter]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null)
            return NotFound();

        return Ok(
            user.ToViewModel()
        );
    }
    
    [HttpGet]
    [Route("tasks/{id:int}")]
    [AuthorizationFilter]
    public async Task<IActionResult> GetByIdWithTasksAsync([FromRoute] int id)
    {
        var user = await _userService.GetByIdWithTasksAsync(id);
        if (user == null)
            return NotFound();
    
        return Ok(
            user.ToViewModelWithTasks()
        );
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> Add([FromBody] UserCreationViewModel userCreationViewModel)
    {
        var addedUser = await _userService.AddAsync(userCreationViewModel.ToEntity());
        if (addedUser == null) return BadRequest("Username already exists!");

        return Ok(addedUser.ToViewModel());
    }

    [HttpPut]
    [Route("{id:int}")]
    [AuthorizationFilter]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserUpdateViewModel userUpdateViewModel)
    {
        var userIdFromContext = HttpContext.Items["UserId"];
        if (userIdFromContext == null) return NotFound("This user does not exist!");

        if ((int)userIdFromContext != id)
            return Unauthorized();

        var user = userUpdateViewModel.ToEntity();
        user.UserId = id;

        try
        {
            user = await _userService.UpdateAsync(user);
        }
        catch (ArgumentNullException)
        {
            return NotFound("A subject you tried to add does not exist!");
        }

        return Ok(user.ToViewModel());
    }

    [HttpDelete]
    [Route("{id:int}")]
    [AuthorizationFilter]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _userService.DeleteAsync(id));
    }
}