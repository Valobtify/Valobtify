namespace Valobtify;

/// <summary>
///     Represents a base class for value objects that encapsulate a single value.
/// </summary>
/// <typeparam name="TSingleValueObject">The type of the value object itself, which must inherit from `SingleValueObject`.</typeparam>
/// <typeparam name="TValue">The type of the value being encapsulated. This type must be non-nullable.</typeparam>
public abstract class SingleValueObject<TSingleValueObject, TValue> : ValueObject
    where TSingleValueObject : SingleValueObject<TSingleValueObject, TValue>,
    ICreatableValueObject<TSingleValueObject, TValue>
    where TValue : notnull
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="SingleValueObject{TSingleValueObject, TValue}" /> class.
    /// </summary>
    protected SingleValueObject(TValue value)
    {
        Value = value;
    }

    /// <summary>
    ///     Gets the encapsulated value of the value object.
    /// </summary>
    public virtual TValue Value { get; }

    /// <summary>
    /// Retrieves an enumeration of the atomic values of the value object for comparison or serialization purposes.
    /// </summary>
    /// <returns>An enumeration of the atomic values contained in the value object.</returns>
    public override IEnumerable<object?> GetAtomicValues()
    {
        yield return Value;
    }

    /// <summary>
    ///     Returns a string representation of the value object.
    /// </summary>
    /// <returns>A string representing the encapsulated value.</returns>
    public override string? ToString()
    {
        return Value.ToString();
    }
}