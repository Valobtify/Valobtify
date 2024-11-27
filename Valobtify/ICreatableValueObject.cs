﻿using Resulver;

namespace Valobtify;

public interface ICreatableValueObject<TValueObject, in TValue>
    where TValueObject : ICreatableValueObject<TValueObject, TValue>
{
    public static abstract Result<TValueObject> Create(TValue? value);
}