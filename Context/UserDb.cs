using Microsoft.EntityFrameworkCore;

public class UserDb : DbContext
{
    public UserDb(DbContextOptions<UserDb> options)
        : base(options) { }

    public DbSet<User> Get => Set<User>();
}