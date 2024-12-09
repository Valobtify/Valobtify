namespace Valobtify;

/// <summary>
///     Represents a base class for value objects that can be compared for equality.
/// </summary>
public abstract class ValueObject : IEquatable<ValueObject>
{
    /// <summary>
    ///     Compares this value object to another for equality.
    /// </summary>
    /// <param name="other">The other value object to compare.</param>
    /// <returns>Returns `true` if the value objects are equal, otherwise `false`.</returns>
    public bool Equals(ValueObject? other)
    {
        return other is not null && ValuesAreEqual(other);
    }

    /// <summary>
    ///     Retrieves the atomic values of the value object for comparison or serialization purposes.
    /// </summary>
    /// <returns>An enumeration of the atomic values contained in the value object.</returns>
    public abstract IEnumerable<object?> GetAtomicValues();

    /// <summary>
    ///     Compares this value object to another object for equality.
    /// </summary>
    /// <param name="obj">The object to compare.</param>
    /// <returns>Returns `true` if the object is a `ValueObject` and they are equal, otherwise `false`.</returns>
    public override bool Equals(object? obj)
    {
        return Equals(obj as ValueObject);
    }

    /// <summary>
    ///     Retrieves a hash code for the value object based on its atomic values.
    /// </summary>
    /// <returns>A hash code for the value object.</returns>
    public override int GetHashCode()
    {
        return GetAtomicValues()
            .Aggregate(default(int), HashCode.Combine);
    }

    /// <summary>
    ///     Compares the atomic values of this value object with another for equality.
    /// </summary>
    /// <param name="other">The other value object to compare.</param>
    /// <returns>Returns `true` if the atomic values of both value objects are equal, otherwise `false`.</returns>
    private bool ValuesAreEqual(ValueObject other)
    {
        return GetAtomicValues()
            .SequenceEqual(other.GetAtomicValues());
    }
}