using Microsoft.EntityFrameworkCore;
using TS.Business.Interfaces;
using TS.Model.Enums;
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

    public async Task<long> AddAsync(int userId, Task task)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.UserId == userId) ?? null;

        if (user == null) throw new Exception("User not found");

        task.UserId = userId;
        task.User = user;

        task.ProgressBarType = ProgressBarType.Type0;

        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();

        return task.TaskId;
    }

    public async Task<IEnumerable<Task>> GetAllForUserAsync(int userId, string status)
    {
        var user = await _context.Users.Include(user => user.Tasks).ThenInclude(task => task.Subtasks)
            .FirstOrDefaultAsync(user => user.UserId == userId);

        if (user is null) throw new Exception("User not found");

        user.Tasks.ForEach(task =>
        {
            UpdateStatus(task);
            SetProgressBarType(task);
        });

        await _context.SaveChangesAsync();

        if (status == "all_tasks") return user.Tasks.AsEnumerable();
        
        var s = status switch
        {
            "0" => Status.New,
            "1" => Status.InProgress,
            "2" => Status.Complete,
            "3" => Status.Overdue,
            _ => Status.New
        };

        return user.Tasks.Where(task => task.Status == s).AsEnumerable();
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

    public async Task<bool> UpdateProgress(int taskId, int progress)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(task => task.TaskId == taskId);

        if (task is null) throw new Exception("Task not found");


        task.Progress = progress;
        UpdateStatus(task, progress);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateTime(int taskId, long time)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(task => task.TaskId == taskId);

        if (task is null) throw new Exception("Task not found");

        task.SpentTime = time;
        await _context.SaveChangesAsync();

        return true;
    }

    private void UpdateStatus(Task task, int progress = -1)
    {
        if (task.Progress != 100 && task.Deadline <= new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds())
        {
            task.Status = Status.Overdue;
            return;
        }

        if (progress == -1) progress = task.Progress;

        task.Status = progress switch
        {
            0 => Status.New,
            > 0 and < 100 => Status.InProgress,
            100 => Status.Complete,
            _ => task.Status
        };
    }

    private void SetProgressBarType(Task task)
    {
        switch (task.Subtasks.Count)
        {
            case 0:
                task.ProgressBarType = ProgressBarType.Type0;
                return;
            case < 3 or > 6:
                task.ProgressBarType = ProgressBarType.Type2;
                return;
        }

        task.ProgressBarType = ProgressBarType.Type1;
    }
}