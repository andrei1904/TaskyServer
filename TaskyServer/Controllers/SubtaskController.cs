using Microsoft.AspNetCore.Mvc;
using TaskyServer.Filters;
using TS.Business.Interfaces;
using TS.Model.Mappers;
using TS.Model.ViewModels.Subtask;

namespace TaskyServer.Controllers;

[ApiController]
[Route("api/subtasks")]
public class SubtaskController : ControllerBase
{
    private readonly ISubtaskService _subtaskService;

    public SubtaskController(ISubtaskService subtaskService)
    {
        _subtaskService = subtaskService;
    }

    [HttpPost]
    [Route("{taskId:int}")]
    [AuthorizationFilter]
    public async Task<IActionResult> AddSubtasksAsync([FromRoute] int taskId,
        [FromBody] List<SubtaskCreationViewModel> subtaskCreationViewModels)
    {
        try
        {
            var userId = HttpContext.Items["UserId"];
            if (userId == null) return Unauthorized();

            var ids = await _subtaskService.AddAsync(taskId,
                subtaskCreationViewModels.Select(subtask => subtask.ToEntity()).ToList());
            return Ok(ids);
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }

    [HttpPut]
    [Route("{subtaskId:int}")]
    [AuthorizationFilter]
    public async Task<IActionResult> UpdateAsync([FromRoute] int subtaskId, [FromBody] SubtaskCreationViewModel subtask)
    {
        var userId = HttpContext.Items["UserId"];
        if (userId == null) return Unauthorized();

        try
        {
            var result = await _subtaskService.Update(subtaskId, subtask.ToEntity());
            return Ok(result.ToViewModel());
        }
        catch (Exception exception)
        {
            return NotFound(exception.Message);
        }
    }
}