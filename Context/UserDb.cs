using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class UserDb : BaseRepository
{
    public UserDb(DbContextOptions<UserDb> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(c => c.Id);
            
    }
}