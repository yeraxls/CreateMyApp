public static class OrdersModules
{
    public static void AddRoutes(WebApplication app)
    {
        RouteGroupBuilder ordersRoutes = app.MapGroup("/orders");

        ordersRoutes.MapPost("/neworder", PostOrder);
        ordersRoutes.MapGet("/{id}", GetOrders);
        ordersRoutes.MapPut("/updateorder", PutOrders);
        ordersRoutes.MapDelete("/deleteorder/{id}", DeleteOrders);
        ordersRoutes.MapPut("/changestatus", ChangeStatus);
        ordersRoutes.MapGet("/gettaskbystatus/{statusOrder}", GetTaskByStatus);
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
            return TypedResults.Ok(await orderService.GetMyOrders(id));
        }
        catch
        {
            return TypedResults.NotFound();
        }
    }

    static async Task<IResult> PutOrders(UpdateOrder order, IOrdersService orderService)
    {
        try
        {
            return TypedResults.Ok(await orderService.PutOrder(order));
        }
        catch
        {
            return TypedResults.NotFound();
        }
    }

    static async Task<IResult> DeleteOrders(int id, IOrdersService orderService)
    {
        try
        {
            return TypedResults.Ok(await orderService.DeleteOrder(id));
        }
        catch
        {
            return TypedResults.NotFound();
        }
    }    

    static async Task<IResult> ChangeStatus(ChangeStatusOrder changeStatusOrder, IOrdersService orderService){
         try
        {
            return TypedResults.Ok(await orderService.ChangeStatus(changeStatusOrder));
        }
        catch
        {
            return TypedResults.NotFound();
        }
    }
    static async Task<IResult> GetTaskByStatus(StatusOrder statusOrder, IOrdersService orderService){
         try
        {
            return TypedResults.Ok(await orderService.GetTaskByStatus(statusOrder));
        }
        catch
        {
            return TypedResults.NotFound();
        }
    }
}