using UDT.Model.ViewModels.Subtask;

namespace TS.Model.ViewModels.Task;

public class TaskSubtasksViewModel
{
    public long TaskId { get; set; }

    public string Domain { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Priority { get; set; }

    public long Deadline { get; set; }

    public long ImposedDeadline { get; set; }

    public List<SubtaskViewModel> Subtasks { get; set; }
}