using Probny2025ZRozwiazaniem.Data;
using Probny2025ZRozwiazaniem.DTOs;
using Probny2025ZRozwiazaniem.Models;


using Microsoft.EntityFrameworkCore;
using Probny2025ZRozwiazaniem.Exceptions;

namespace Probny2025ZRozwiazaniem.Services;

public class DbService : IDbService
{
    
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<OrdersDTO> GetOrders(int orderId)
    {
        var order = await _context.Orders
            .Select((Orders e) => new OrdersDTO
            {
                OrderId = e.OrderId,
                OrderedAt = e.OrderedAt,
                FulfilledAt = e.FulfilledAt,
                Status = e.Status.Name,
                ClientInfo = new ClientInfo()
                {
                    FirstName = e.Client.FirstName,
                    LastName = e.Client.LastName,
                },
                Products = e.ProductsOrdereds.Select(a => new ProductAmount()
                {
                    ProductName = a.Product.Name,
                    ProductPrice = a.Product.Price,
                    Amount = a.Amount
                }).ToList()
            }).FirstOrDefaultAsync(e => e.OrderId == orderId);

        if (order is null)
            throw new NotFoundException("the order was not found");

        return order;
    }

    public async Task FulfillOrder(int orderId, FulfillOrderDTO fulfillOrderDTO)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId);

            if (order is null)
            {
                throw new NotFoundException("no order was found");
            }

            var status = await _context.Statuses.FirstOrDefaultAsync(s => s.Name == fulfillOrderDTO.StatusName);
            if (status is null)
            {
                throw new NotFoundException("no status was found");
            }

            if (order.FulfilledAt is not null)
            {
                throw new ConflixtException("Already fulfilled");
            }
            
            order.FulfilledAt = DateTime.Now;
            order.StatusId = status.StatusId;


            var relatedProduct = _context.ProductsOrdereds
                .Where(prord => prord.OrderId == orderId);
            _context.ProductsOrdereds.RemoveRange(relatedProduct);
            
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception e)
        {
            transaction.RollbackAsync();
            throw;
        }
        
        
    }



}