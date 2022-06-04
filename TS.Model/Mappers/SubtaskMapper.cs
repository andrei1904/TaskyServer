using TS.Model.Entities;
using UDT.Model.ViewModels.Subtask;

namespace TS.Model.Mappers;

public static class SubtaskMapper
{
    public static Subtask ToEntity(this SubtaskCreationViewModel subtaskCreationViewModel)
    {
        var subtask = new Subtask
        {
            Title = subtaskCreationViewModel.Title,
            Description = subtaskCreationViewModel.Description,
            isCompleted = subtaskCreationViewModel.isCompleted
        };

        return subtask;
    }
    
    public static SubtaskViewModel ToViewModel(this Subtask subtask)
    {
        var subtaskViewModel = new SubtaskViewModel()
        {
            SubtaskId = subtask.SubtaskId,
            Title = subtask.Title,
            Description = subtask.Description,
            isCompleted = subtask.isCompleted
        };

        return subtaskViewModel;
    }
}