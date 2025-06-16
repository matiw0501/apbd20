using Probny2025ZRozwiazaniem.DTOs;

namespace Probny2025ZRozwiazaniem.Services;

public interface IDbService
{
    Task<OrdersDTO> GetOrders(int orderId);
    Task FulfillOrder(int orderId, FulfillOrderDTO fulfillOrderDTO);
}