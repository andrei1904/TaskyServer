using TS.Model.ViewModels.Subtask;

namespace TS.Model.ViewModels.Task;

public class TaskSubtasksViewModel
{
    public TaskViewModel Task { get; set; }

    public List<SubtaskViewModel> Subtasks { get; set; }
}