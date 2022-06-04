using TS.Model.Entities;

namespace TS.Business.Interfaces;

public interface ISubtaskService
{
    Task<int> AddAsync(int taskId, List<Subtask> subtasks);
}