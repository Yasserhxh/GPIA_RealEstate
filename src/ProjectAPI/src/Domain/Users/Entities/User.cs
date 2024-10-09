using Microsoft.AspNetCore.Identity;

namespace ProjectAPI.Domain.Users.Entities;
/// <summary>
/// Represents a user in the system.
/// </summary>
public class User : IdentityUser
{
    // Add your custom properties here
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
