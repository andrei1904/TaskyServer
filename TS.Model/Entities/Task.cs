﻿using TS.Model.Enums;

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

    public List<Subtask> Subtasks { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }
}