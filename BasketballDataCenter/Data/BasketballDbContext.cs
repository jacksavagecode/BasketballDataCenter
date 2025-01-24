using BasketballDataCenter.Models;
using BasketBallDataCenter.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class BasketballDbContext : IdentityDbContext<User>
{
    public BasketballDbContext(DbContextOptions<BasketballDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> User { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<UserTeam> UserTeams { get; set; }
}
