namespace Ordering.Application.Orders.Queries.GetOrdersByCustomer;

public record GetOrdersByCustomerQuery(Guid CustomerId) : IQuery<GetOrdersByCustomerRresult>;
public record GetOrdersByCustomerRresult(IEnumerable<OrderDto> Orders);

