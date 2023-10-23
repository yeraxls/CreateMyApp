using Microsoft.EntityFrameworkCore;

public class OrdersService : IOrdersService {

    private readonly OrderDb _db;
    public OrdersService(OrderDb db)
    {
        _db = db;
    }

    public async Task<IResult> PostOrder(NewOrder order)
    {
        try
        {
            var orderdb = new Order{
                UserId = order.UserId,
                Name = order.Name,
                DateOfOrder = DateTime.Now,
                CustomType = order.CustomType,
                Description = order.Description ??"",
                Price = order.Price ?? 0.0
            };
            await _db.Insertar(orderdb);
            _db.SalvarCambios();
            return TypedResults.Created($"/order/{orderdb.Id}", order);
        }
        catch
        {
            return TypedResults.NotFound();
        }
    }

    public async Task<IResult> GetMyOrders(int userId)
    {
        try
        {
            var orders = await _db
                .Queryable<Order>(c => c.UserId == userId).ToListAsync();
            return TypedResults.Ok(orders);
        }
        catch
        {
            return TypedResults.NotFound();
        }
    }
}
public interface IOrdersService {

    Task<IResult> PostOrder(NewOrder order);

    Task<IResult> GetMyOrders(int userId);
}