using TS.Business.Interfaces;
using Task = TS.Model.Entities.Task;

namespace TS.Business.implementation;

public class Service : IService
{
    public Task<Task?> AddTask(long userId, Task task)
    {
        throw new NotImplementedException();
    }
}