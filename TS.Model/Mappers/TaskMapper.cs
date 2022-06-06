using TS.Model.Enums;
using TS.Model.ViewModels.Task;
using Task = TS.Model.Entities.Task;

namespace TS.Model.Mappers;

public static class TaskMapper
{
    public static Task ToEntity(this TaskCreationViewModel taskCreationViewModel)
    {
        var task = new Task
        {
            Domain = taskCreationViewModel.Domain,
            Title = taskCreationViewModel.Title,
            Description = taskCreationViewModel.Description,
            Priority = (Priority)Enum.Parse(typeof(Priority), taskCreationViewModel.Priority),
            Deadline = taskCreationViewModel.Deadline,
            ImposedDeadline = taskCreationViewModel.ImposedDeadline,
            Status = (Status)Enum.Parse(typeof(Status), taskCreationViewModel.Status),
            SpentTime = taskCreationViewModel.SpentTime,
            Difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), taskCreationViewModel.Difficulty),
            Progress = taskCreationViewModel.Progress
        };

        return task;
    }

    public static TaskViewModel ToViewModel(this Task task)
    {
        var taskViewModel = new TaskViewModel
        {
            TaskId = task.TaskId,
            Domain = task.Domain,
            Title = task.Title,
            Description = task.Description,
            Priority = task.Priority.ToString(),
            Deadline = task.Deadline,
            ImposedDeadline = task.ImposedDeadline,
            Status = task.Status.ToString(),
            SpentTime = task.SpentTime,
            Difficulty = task.Difficulty.ToString(),
            Progress = task.Progress
        };

        return taskViewModel;
    }

    public static TaskSubtasksViewModel ToTaskSubtasksViewModel(this Task task)
    {
        var taskViewModel = new TaskSubtasksViewModel
        {
            Task = task.ToViewModel(),
            Subtasks = task.Subtasks.Select(subtask => subtask.ToViewModel()).ToList()
        };

        return taskViewModel;
    }
}