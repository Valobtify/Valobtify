namespace Valobtify;

public abstract class SingleValueObject<TSingleValueObject, TValue> : ValueObject
    where TSingleValueObject : SingleValueObject<TSingleValueObject, TValue>, ICreatableValueObject<TSingleValueObject, TValue>
    where TValue : notnull
{
    public TValue Value { get; protected init; } = default!;

    protected SingleValueObject(TValue value)
    {
        var validationResult = TSingleValueObject.Create(value);

        if (validationResult.IsFailure)
        {
            throw new InvalidDataException("value is not valid");
        }
        
        Value = value;
    }

    protected SingleValueObject()
    {
        
    }

    public override IEnumerable<object?> GetAtomicValues()
    {
        yield return Value;
    }

    public override string? ToString()
    {
        return Value.ToString();
    }
}
