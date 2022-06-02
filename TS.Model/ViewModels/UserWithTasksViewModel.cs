using Task = TS.Model.Entities.Task;

namespace TS.Model.ViewModels;

public class UserWithTasksViewModel
{
    public long Id { get; set; }

    public string Username { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public List<Task> Tasks { get; set; }
}