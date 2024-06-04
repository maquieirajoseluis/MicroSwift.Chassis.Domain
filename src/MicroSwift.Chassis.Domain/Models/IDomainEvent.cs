namespace MicroSwift.Chassis.Domain.Models;

public interface IDomainEvent
{
    DateTime OccurredAt { get; }
}