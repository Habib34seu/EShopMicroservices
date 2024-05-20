using Ordering.Domain.Abstractions;

namespace Ordering.Domain.Models;

public class Custormer : Entity<CustomerId>
{
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;

    public static Custormer Create(CustomerId id, string name, string email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        var customer = new Custormer
        {
            Id = id,
            Name = name,
            Email = email
        };

        return customer;
    }
}
