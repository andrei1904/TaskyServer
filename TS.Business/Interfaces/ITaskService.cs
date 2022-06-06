using Task = TS.Model.Entities.Task;

namespace TS.Business.Interfaces;

public interface ITaskService
{
    Task<long> AddAsync(int userId, Task task);
    Task<IEnumerable<Task>> GetAllForUserAsync(int userId);
    Task<bool> DeleteTaskForUser(int userId, int taskId);
    Task<bool> UpdateProgress(int taskId, int progress);
    Task<bool> UpdateTime(int taskId, long time);
}