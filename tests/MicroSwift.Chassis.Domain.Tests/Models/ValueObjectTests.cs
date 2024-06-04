using FluentAssertions;
using MicroSwift.Chassis.Domain.Models;

namespace MicroSwift.Chassis.Domain.Tests.Models;

public class ValueObjectTests
{
    private class TestValueObject : ValueObject<TestValueObject>
    {
        public int Value { get; }

        public TestValueObject(int value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }

    private class AnotherTestValueObject : ValueObject<AnotherTestValueObject>
    {
        public int Value { get; }

        public AnotherTestValueObject(int value)
        {
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }

    [Fact]
    public void EqualsOperator_ShouldReturnTrue_WhenBothObjectsAreNull()
    {
        // Arrange
        TestValueObject obj1 = null;
        TestValueObject obj2 = null;

        // Act & Assert
        (obj1 == obj2).Should().BeTrue();
    }

    [Fact]
    public void EqualsOperator_ShouldReturnFalse_WhenFirstObjectIsNotNullAndSecondObjectIsNull()
    {
        // Arrange
        TestValueObject obj1 = new TestValueObject(1);
        TestValueObject obj2 = null;

        // Act & Assert
        (obj1 == obj2).Should().BeFalse();
    }

    [Fact]
    public void EqualsOperator_ShouldReturnFalse_WhenFirstObjectIsNullAndSecondIsNot()
    {
        // Arrange
        TestValueObject obj1 = null;
        TestValueObject obj2 = new TestValueObject(1);

        // Act & Assert
        (obj1 == obj2).Should().BeFalse();
    }

    [Fact]
    public void EqualsOperator_ShouldReturnTrue_WhenBothObjectsHaveSameValue()
    {
        // Arrange
        var obj1 = new TestValueObject(1);
        var obj2 = new TestValueObject(1);

        // Act & Assert
        (obj1 == obj2).Should().BeTrue();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenComparedWithCompletelyDifferentType()
    {
        // Arrange
        var obj = new TestValueObject(1);
        var differentTypeObject = new { Value = 1 }; // Un objeto de tipo completamente diferente

        // Act
        var result = obj.Equals(differentTypeObject);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenComparedWithDifferentValueObjectType()
    {
        // Arrange
        var obj = new TestValueObject(1);
        var other = new AnotherTestValueObject(1);

        // Act & Assert
        obj.Equals(other).Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenComparedWithNonValueObject()
    {
        // Arrange
        var obj = new TestValueObject(1);
        var otherObj = new object();

        // Act
        var result = obj.Equals(otherObj);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenComparedWithNull()
    {
        // Arrange
        var obj = new TestValueObject(1);

        // Act
        var result = obj.Equals(null);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_ShouldReturnTrue_WhenObjectsAreEqualAsObject()
    {
        // Arrange
        var obj1 = new TestValueObject(1);
        var obj2 = new TestValueObject(1);

        // Act
        var result = obj1.Equals((object)obj2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_ShouldReturnTrue_WhenValueObjectsHaveSameValue()
    {
        // Arrange
        var obj1 = new TestValueObject(1);
        var obj2 = new TestValueObject(1);

        // Act
        var result = obj1.Equals(obj2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_ShouldReturnFalse_WhenValueObjectsHaveDifferentValues()
    {
        // Arrange
        var obj1 = new TestValueObject(1);
        var obj2 = new TestValueObject(2);

        // Act
        var result = obj1.Equals(obj2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void GetHashCode_ShouldReturnSameHash_WhenObjectsHaveSameValue()
    {
        // Arrange
        var obj1 = new TestValueObject(1);
        var obj2 = new TestValueObject(1);

        // Act
        var hash1 = obj1.GetHashCode();
        var hash2 = obj2.GetHashCode();

        // Assert
        hash1.Should().Be(hash2);
    }

    [Fact]
    public void NotEqualsOperator_ShouldReturnFalse_WhenBothObjectsAreNull()
    {
        // Arrange
        TestValueObject obj1 = null;
        TestValueObject obj2 = null;

        // Act & Assert
        (obj1 != obj2).Should().BeFalse();
    }

    [Fact]
    public void NotEqualsOperator_ShouldReturnTrue_WhenFirstObjectIsNotNullAndSecondObjectIsNull()
    {
        // Arrange
        TestValueObject obj1 = new TestValueObject(1);
        TestValueObject obj2 = null;

        // Act & Assert
        (obj1 != obj2).Should().BeTrue();
    }

    [Fact]
    public void NotEqualsOperator_ShouldReturnTrue_WhenObjectsHaveDifferentValues()
    {
        // Arrange
        var obj1 = new TestValueObject(1);
        var obj2 = new TestValueObject(2);

        // Act & Assert
        (obj1 != obj2).Should().BeTrue();
    }
}
