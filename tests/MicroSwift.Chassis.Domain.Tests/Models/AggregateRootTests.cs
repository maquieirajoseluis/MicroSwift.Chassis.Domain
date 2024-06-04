using FluentAssertions;
using MicroSwift.Chassis.Domain.Models;

namespace MicroSwift.Chassis.Domain.Tests.Models;

public class AggregateRootTests
{
    private class TestAggregateRoot : AggregateRoot<Guid>
    {
        public TestAggregateRoot() : base()
        {
            Id = Guid.NewGuid();
        }

        public TestAggregateRoot(Guid id) : base(id) { }

        public void AddTestEvent(IDomainEvent domainEvent)
        {
            AddDomainEvent(domainEvent);
        }
    }

    private class TestDomainEvent : IDomainEvent
    {
        public DateTime OccurredAt { get; } = DateTime.UtcNow;
    }

    [Fact]
    public void AddDomainEvent_ShouldAddEvent_WhenCalled()
    {
        // Arrange
        var aggregate = new TestAggregateRoot();
        var domainEvent = new TestDomainEvent();

        // Act
        aggregate.AddTestEvent(domainEvent);

        // Assert
        aggregate.DomainEvents.Should().Contain(domainEvent);
    }

    [Fact]
    public void ClearDomainEvents_ShouldClearAllEvents_WhenCalled()
    {
        // Arrange
        var aggregate = new TestAggregateRoot();
        var domainEvent = new TestDomainEvent();
        aggregate.AddTestEvent(domainEvent);

        // Act
        aggregate.ClearDomainEvents();

        // Assert
        aggregate.DomainEvents.Should().BeEmpty();
    }

    [Fact]
    public void Constructor_ShouldInitializeAggregateRoot_WhenCalledWithValidId()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var aggregate = new TestAggregateRoot(id);

        // Assert
        aggregate.Id.Should().Be(id);
    }

    [Fact]
    public void Constructor_ShouldInitializeAggregateRoot_WhenCalledWithoutParameters()
    {
        // Act
        var aggregate = new TestAggregateRoot();

        // Assert
        aggregate.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void DomainEvents_ShouldReturnReadOnlyList_WhenAccessed()
    {
        // Arrange
        var aggregate = new TestAggregateRoot();
        var domainEvent = new TestDomainEvent();
        aggregate.AddTestEvent(domainEvent);

        // Act
        var domainEvents = aggregate.DomainEvents;

        // Assert
        domainEvents.Should().BeOfType<List<IDomainEvent>>().Which.Should().Contain(domainEvent);
    }
}
