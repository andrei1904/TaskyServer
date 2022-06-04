using Microsoft.EntityFrameworkCore;
using TS.Business.Interfaces;
using TS.Repository;
using Task = TS.Model.Entities.Task;

namespace TS.Business.Implementations;

public class TaskService : ITaskService
{
    private readonly DataContext _context;

    public TaskService(DataContext context)
    {
        _context = context;
    }

    public async Task<Task?> AddAsync(int userId, Task task)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.UserId == userId) ?? null;

        if (user == null) throw new Exception("User not found");

        task.UserId = userId;
        task.User = user;

        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();

        return task;
    }

    public async Task<IEnumerable<Task>> GetAllForUserAsync(int userId)
    {
        var user = await _context.Users.Include(user => user.Tasks).ThenInclude(task => task.Subtasks).FirstOrDefaultAsync(user => user.UserId == userId);

        if (user is null) throw new Exception("User not found");
        
        return user.Tasks.AsEnumerable();
    }

    public async Task<bool> DeleteTaskForUser(int userId, int taskId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.UserId == userId);

        if (user is null) throw new Exception("User not found");

        var task = await _context.Tasks.FirstOrDefaultAsync(task => task.TaskId == taskId);

        if (task is null) throw new Exception("Task not found");

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return true;
    }
}