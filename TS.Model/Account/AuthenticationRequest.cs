using System.ComponentModel.DataAnnotations;

namespace TS.Model.Account;

public class AuthenticationRequest
{
    [Required] public string Username { get; set; }

    [Required] public string Password { get; set; }
}