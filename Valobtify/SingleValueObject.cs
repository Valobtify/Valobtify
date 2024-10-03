namespace Valobtify;

public abstract class SingleValueObject<TSingleValueObject, TValue> : ValueObject
    where TSingleValueObject : SingleValueObject<TSingleValueObject, TValue>, ICreatableValueObject<TSingleValueObject, TValue>
    where TValue : notnull
{
    public virtual TValue Value { get; }

    protected SingleValueObject(TValue value) => Value = value;

    public override IEnumerable<object?> GetAtomicValues()
    {
        yield return Value;
    }

    public override string? ToString()
    {
        if (Value is not null)
        {
            return Value.ToString();
        }
        return null;
    }
}
