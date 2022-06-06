using TS.Model.Entities;
using TS.Model.Enums;
using TS.Model.ViewModels.Subtask;

namespace TS.Model.Mappers;

public static class SubtaskMapper
{
    public static Subtask ToEntity(this SubtaskCreationViewModel subtaskCreationViewModel)
    {
        var subtask = new Subtask
        {
            Title = subtaskCreationViewModel.Title,
            Description = subtaskCreationViewModel.Description,
            Status = (SubtaskStatus)Enum.Parse(typeof(SubtaskStatus), subtaskCreationViewModel.Status),
            Difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), subtaskCreationViewModel.Difficulty)
        };

        return subtask;
    }

    public static SubtaskViewModel ToViewModel(this Subtask subtask)
    {
        var subtaskViewModel = new SubtaskViewModel
        {
            SubtaskId = subtask.SubtaskId,
            Title = subtask.Title,
            Description = subtask.Description,
            Status = subtask.Status.ToString(),
            Difficulty = subtask.Difficulty.ToString()
        };

        return subtaskViewModel;
    }
}