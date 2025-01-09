using Microsoft.EntityFrameworkCore;

namespace SocialApp.Models;

public class SocialAppDbContext : DbContext
{
    public required DbSet<User> Users { get; set; }

    public SocialAppDbContext(DbContextOptions<SocialAppDbContext> options) : base(options)
    {
        
    }
}
