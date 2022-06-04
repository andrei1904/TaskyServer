using Microsoft.EntityFrameworkCore;
using TS.Business.Interfaces;
using TS.Model.Entities;
using TS.Repository;

namespace TS.Business.Implementations;

public class SubtaskService : ISubtaskService
{
    private readonly DataContext _context;

    public SubtaskService(DataContext context)
    {
        _context = context;
    }

    public async Task<int> AddAsync(int taskId, List<Subtask> subtasks)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(task => task.TaskId == taskId) ?? null;

        if (task == null) throw new Exception("Task does not exist");

        subtasks.ForEach(subtask =>
        {
            subtask.Task = task;
            subtask.TaskId = taskId;
        }); 
        
        await _context.Subtasks.AddRangeAsync(subtasks);
        await _context.SaveChangesAsync();

        return subtasks.Count;
    }
}