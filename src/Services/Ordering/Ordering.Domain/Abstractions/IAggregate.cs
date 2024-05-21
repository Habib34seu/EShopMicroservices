﻿namespace Ordering.Domain.Abstractions;

public interface IAggregate<T> : IAggregate, IEntity<T>
{
}

    public interface IAggregate : IEntity
{
    IReadOnlyList<IDomainEvent> IDomainEvents {  get; }
    IDomainEvent[] ClearDomainEvents();
}