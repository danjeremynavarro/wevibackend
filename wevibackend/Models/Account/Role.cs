using Microsoft.AspNetCore.Identity;

namespace wevibackend.Models.Account;

public class Role : IdentityRole
{
    public string? Description { get; set; }
}