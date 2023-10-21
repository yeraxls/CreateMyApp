using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class UserDb : DbContext
{
    public UserDb(DbContextOptions<UserDb> options)
        : base(options) { }

    public DbSet<User> Get => Set<User>();
    public async Task<T> Insertar<T>(T elemento) where T : class
        {
            await AddAsync<T>(elemento);
            return elemento;
        }
        
        public async void SalvarCambios()
        {
            await SaveChangesAsync();
        }

        public void Eliminar<T>(T elemento) where T: class
        {
            Remove<T>(elemento);
        }

        public IQueryable<T> Queryable<T>(Expression<Func<T, bool>>? expression = null) where T: class
        {
            if(expression == null)
                return Set<T>();
            return Set<T>().Where(expression);
        }
}