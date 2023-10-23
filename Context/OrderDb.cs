using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class OrderDb : BaseRepository
{
    public OrderDb(DbContextOptions<OrderDb> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasKey(c => c.Id);
    }
}