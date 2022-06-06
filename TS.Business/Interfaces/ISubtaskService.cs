using TS.Model.Entities;
using TS.Model.ViewModels.Subtask;

namespace TS.Business.Interfaces;

public interface ISubtaskService
{
    Task<List<long>> AddAsync(int taskId, List<Subtask> subtasks);
    Task<Subtask> Update(int subtaskId, Subtask subtask);
}