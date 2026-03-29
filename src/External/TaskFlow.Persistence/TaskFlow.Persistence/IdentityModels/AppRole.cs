using Microsoft.AspNetCore.Identity;
using System.Reflection.Metadata.Ecma335;

namespace TaskFlow.Persistence.IdentityModels;

public class AppRole : IdentityRole
{
    public AppRole() => Id = Guid.NewGuid().ToString();
    public AppRole(string roleName)
    {
        Name = roleName;
    }
}
