using FluentAssertions;
using MicroSwift.Chassis.Domain.Models;

namespace MicroSwift.Chassis.Domain.Tests.Models;

public class EntityTests
{
    private class TestEntity : Entity<Guid?>
    {
        public TestEntity(Guid? id) : base(id) { }
        public TestEntity() : base()
        {
            Id = Guid.NewGuid();
        }
    }

    private class AnotherTestEntity : Entity<Guid?>
    {
        public AnotherTestEntity(Guid? id) : base(id) { }
        public AnotherTestEntity() : base(Guid.NewGuid()) { }
    }

    [Fact]
    public void Constructor_ShouldThrowArgumentNullException_WhenIdIsNull()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new TestEntity(null));
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenComparedWithDifferentEntitySubclass()
    {
        // Arrange
        var id = Guid.NewGuid();
        var entity1 = new TestEntity(id);
        var entity2 = new AnotherTestEntity(id);

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenComparedWithNonEntityObject()
    {
        // Arrange
        var entity = new TestEntity();
        var differentTypeObject = new object();

        // Act
        var result = entity.Equals(differentTypeObject);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenComparedWithNull()
    {
        // Arrange
        var entity = new TestEntity();

        // Act
        var result = entity.Equals(null);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenEntitiesHaveDifferentIds()
    {
        // Arrange
        var entity1 = new TestEntity();
        var entity2 = new TestEntity();

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenComparedWithSelf()
    {
        // Arrange
        var entity = new TestEntity();

        // Act
        var result = entity.Equals(entity);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_ShouldReturnTrue_WhenEntitiesHaveSameId()
    {
        // Arrange
        var id = Guid.NewGuid();
        var entity1 = new TestEntity(id);
        var entity2 = new TestEntity(id);

        // Act
        var result = entity1.Equals(entity2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void GetHashCode_ShouldReturnDifferentHashCode_WhenEntitiesHaveDifferentIds()
    {
        // Arrange
        var entity1 = new TestEntity();
        var entity2 = new TestEntity();

        // Act
        var hash1 = entity1.GetHashCode();
        var hash2 = entity2.GetHashCode();

        // Assert
        hash1.Should().NotBe(hash2);
    }

    [Fact]
    public void GetHashCode_ShouldReturnSameHashCode_WhenEntitiesHaveSameId()
    {
        // Arrange
        var id = Guid.NewGuid();
        var entity1 = new TestEntity(id);
        var entity2 = new TestEntity(id);

        // Act
        var hash1 = entity1.GetHashCode();
        var hash2 = entity2.GetHashCode();

        // Assert
        hash1.Should().Be(hash2);
    }
}
