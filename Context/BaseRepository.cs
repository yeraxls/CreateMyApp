using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class BaseRepository : DbContext {
    public BaseRepository(DbContextOptions options)
        : base(options) { }
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