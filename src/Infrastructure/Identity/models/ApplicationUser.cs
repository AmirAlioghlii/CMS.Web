using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.models;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
}