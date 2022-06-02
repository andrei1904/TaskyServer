namespace TS.Model.Entities;

public class Subtask
{
    public long SubtaskId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public bool isCompleted { get; set; }
    
    public long TaskId { get; set; }
    public Task Task { get; set; }
}