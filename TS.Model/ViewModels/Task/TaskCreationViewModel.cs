using TS.Model.Entities;

namespace TS.Model.ViewModels.Task;

public class TaskCreationViewModel
{
    public string Domain { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Priority { get; set; }

    public long Deadline { get; set; }

    public long ImposedDeadline { get; set; }
}