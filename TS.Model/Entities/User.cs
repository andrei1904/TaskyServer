namespace TS.Model.Entities;

public class User
{
    public long UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public List<Task> Tasks { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiryTime { get; set; }
}