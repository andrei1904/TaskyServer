using Microsoft.AspNetCore.Mvc;
using TaskyServer.Filters;
using TS.Business.Interfaces;
using TS.Model.Mappers;
using TS.Model.ViewModels.Task;

namespace TaskyServer.Controllers;

[ApiController]
[Route("api/tasks")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost]
    [Route("")]
    [AuthorizationFilter]
    public async Task<IActionResult> AddAsync([FromBody] TaskCreationViewModel taskCreationViewModel)
    {
        try
        {
            var userId = HttpContext.Items["UserId"];
            if (userId == null) return Unauthorized();

            await _taskService.AddAsync((int)userId, taskCreationViewModel.ToEntity());
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }

        return Ok();
    }

    [HttpGet]
    [Route("")]
    [AuthorizationFilter]
    public async Task<IActionResult> GetAllForUserAsync()
    {
        try
        {
            var userId = HttpContext.Items["UserId"];
            if (userId == null) return Unauthorized();

            var tasks = await _taskService.GetAllForUserAsync((int)userId);
            return Ok(tasks.Select(task => task.ToTaskSubtasksViewModel()));
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpDelete]
    [Route("{taskId:int}")]
    [AuthorizationFilter]
    public async Task<IActionResult> DeleteTaskForUserAsync([FromRoute] int taskId)
    {
        try
        {
            var userId = HttpContext.Items["UserId"];
            if (userId == null) return Unauthorized();

            var result = await _taskService.DeleteTaskForUser((int)userId, taskId);
            return Ok(result);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }
}