using Microsoft.AspNetCore.Identity;

namespace TaskFlow.Persistence.IdentityModels;

public class AppUser : IdentityUser
{
    public AppUser()
    {
        Id = Guid.NewGuid().ToString();
    }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string FullName => $"{Name} {LastName?.ToUpper()}";
}
