namespace Valobtify
{
    public abstract class SingleValueObject<TValue> : ValueObject
    where TValue : class
    {
        public virtual required TValue Value { get; init; }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return Value.ToString() ??
                throw new NullReferenceException("value is null");
        }

        public static explicit operator string(SingleValueObject<TValue> value)
        {
            return value.ToString();
        }
    }
}
