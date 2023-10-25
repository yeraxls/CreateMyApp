using Microsoft.EntityFrameworkCore;

public class OrdersService : IOrdersService
{

    private readonly OrderDb _db;
    public OrdersService(OrderDb db)
    {
        _db = db;
    }

    public async Task<IResult> PostOrder(NewOrder order)
    {
        try
        {
            var orderdb = new Order
            {
                UserId = order.UserId,
                Name = order.Name,
                DateOfOrder = DateTime.Now,
                CustomType = order.CustomType,
                Description = order.Description ?? "",
                Price = order.Price ?? 0.0,
                StatusOrder = StatusOrder.Pending
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

    public async Task<IResult> PutOrder(UpdateOrder order)
    {
        try
        {
            var orderdb = _db.Queryable<Order>(c => c.Id == order.Id).FirstOrDefault();
            if (orderdb is null) return TypedResults.NotFound();
            await UpdateOrder(orderdb, order);
            _db.SalvarCambios();
            return TypedResults.Created($"/order/{orderdb.Id}", order);
        }
        catch
        {
            return TypedResults.NotFound();
        }
    }

    private async Task UpdateOrder(Order orderdb, UpdateOrder order)
    {
        orderdb.Name = order.Name;
        orderdb.CustomType = order.CustomType;
        orderdb.Description = order.Description ?? orderdb.Description;
        orderdb.Price = order.Price ?? orderdb.Price;
        orderdb.StatusOrder = order.StatusOrder;
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

    public async Task<IResult> DeleteOrder(int orderId)
    {
        try
        {
            var orderdb = await _db.Queryable<Order>(c => c.Id == orderId).FirstOrDefaultAsync();
            if (orderdb is null) return TypedResults.NotFound();
            _db.Eliminar(orderdb);
            _db.SalvarCambios();
            return TypedResults.Created($"/order/{orderdb.Id}");
        }
        catch
        {
            return TypedResults.NotFound();
        }
    }
}
