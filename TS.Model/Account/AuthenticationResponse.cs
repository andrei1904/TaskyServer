using TS.Model.ViewModels;

namespace TS.Model;

public class AuthenticationResponse
{
    public string? AccessToken { get; set; }

    public string? RefreshToken { get; set; }

    public UserViewModel User { get; set; }
}