using Microsoft.EntityFrameworkCore;

namespace Iox.Api.Models;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    {
    }

    public DbSet<User>? Users { get; set; }
    public DbSet<Account>? Accounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(b => b.Account)
            .WithOne(i => i.User)
            .HasForeignKey<Account>(b => b.UserForeignKey);
    }
}