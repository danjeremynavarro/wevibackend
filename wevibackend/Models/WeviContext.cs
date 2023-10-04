using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using wevibackend.Models.Account;

namespace wevibackend.Models;
using Microsoft.EntityFrameworkCore;

public class WeviContext : IdentityDbContext<User>
{
    public WeviContext(DbContextOptions<WeviContext> options) : base(options){}
    public DbSet<TodoItem> TodoItems { get; set; } = null;
    public DbSet<User> Users { get; set; } = null;
    public DbSet<Role> Roles { get; set; } = null;
}