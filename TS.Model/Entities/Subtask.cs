using TS.Model.Enums;

namespace TS.Model.Entities;

public class Subtask
{
    public long SubtaskId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public SubtaskStatus Status { get; set; }

    public Difficulty Difficulty { get; set; }

    public long TaskId { get; set; }

    public Task Task { get; set; }
}