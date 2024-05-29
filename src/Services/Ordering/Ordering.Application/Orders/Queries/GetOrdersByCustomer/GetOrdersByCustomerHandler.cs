

namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

public class GetOrdersByCustomerHandler(IApplicationDbContext dbContext)
    : IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerRresult>
{
    public async Task<GetOrdersByCustomerRresult> Handle(GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
    {
        // get the orders by customer using dbContext
        // return result

        var orders = await dbContext.Orders
                    .Include(o => o.OrderItems)
                    .AsNoTracking()
                    .Where(o => o.CustomerId == CustomerId.Of(query.CustomerId))
                    .OrderBy(o => o.OrderName.Value)
                    .ToListAsync(cancellationToken);

        return new GetOrdersByCustomerRresult(orders.ToOrderDtoList());
    }
}
