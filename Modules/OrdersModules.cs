public static class OrdersModules
{
    public static void AddRoutes(WebApplication app)
    {
        RouteGroupBuilder ordersRoutes = app.MapGroup("/orders");

        ordersRoutes.MapPost("/neworder", PostOrder);
        ordersRoutes.MapGet("/{id}", GetOrders);
    }
    static async Task<IResult> PostOrder(NewOrder order, IOrdersService orderService)
    {
        try
        {
            return TypedResults.Ok(await orderService.PostOrder(order));
        }
        catch
        {
            return TypedResults.NotFound();
        }
    }
    static async Task<IResult> GetOrders(int id, IOrdersService orderService)
    {
        try
        {
            return TypedResults.Ok(orderService.GetMyOrders(id));
        }
        catch
        {
            return TypedResults.NotFound();
        }
    }

    
}