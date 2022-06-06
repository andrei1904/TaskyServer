using TS.Model.Enums;

namespace TS.Model.ViewModels.Subtask;

public class SubtaskCreationViewModel
{
    public string Title { get; set; }

    public string Description { get; set; }

    public string Status { get; set; }
    
    public string Difficulty { get; set; }
}