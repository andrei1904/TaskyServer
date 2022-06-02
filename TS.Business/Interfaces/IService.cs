using Task = TS.Model.Entities.Task;

namespace TS.Business.Interfaces;

public interface IService
{
    Task<Task?> AddTask(long userId, Task task);
}