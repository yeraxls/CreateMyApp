public interface IOrdersService {

    Task<IResult> PostOrder(NewOrder order);

    Task<IResult> GetMyOrders(int userId);
    Task<IResult> PutOrder(UpdateOrder order);
    Task<IResult> DeleteOrder(int orderId);
}