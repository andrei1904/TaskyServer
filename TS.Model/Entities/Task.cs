using TS.Model.Enums;

namespace TS.Model.Entities;

public class Task
{
    public long TaskId { get; set; }

    public string Domain { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public Priority Priority { get; set; }

    public long Deadline { get; set; }

    public long ImposedDeadline { get; set; }
    
    public Status Status { get; set; }
    
    public long SpentTime { get; set; }
    
    public Difficulty Difficulty { get; set; }
    
    public List<Subtask> Subtasks { get; set; }
    
    public int Progress { get; set; }
    
    public long UserId { get; set; }
    
    public User User { get; set; }
}