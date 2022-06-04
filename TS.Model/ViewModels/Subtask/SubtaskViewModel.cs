namespace UDT.Model.ViewModels.Subtask;

public class SubtaskViewModel
{
    public long SubtaskId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public bool isCompleted { get; set; }
}