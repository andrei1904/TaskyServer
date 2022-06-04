using Task = TS.Model.Entities.Task;

namespace TS.Business.Interfaces;

public interface ITaskService
{
    Task<Task?> AddAsync(int userId, Task task);
    Task<IEnumerable<Task>> GetAllForUserAsync(int userId);
    Task<bool> DeleteTaskForUser(int userId, int taskId);
}