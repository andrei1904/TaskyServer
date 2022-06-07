using TS.Model.Entities;

namespace TS.Business.Interfaces;

public interface ISubtaskService
{
    Task<List<long>> AddAsync(int taskId, List<Subtask> subtasks);
    Task<Subtask> Update(int subtaskId, Subtask subtask);
}