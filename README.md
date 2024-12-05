


### Table of Contents

- [Overview](#overview)
- [Installation](#installation)
- [Usage](#usage)
- [Single-Value Objects](#single-value-objects)
- [Integrate with EF Core](https://github.com/Valobtify/Valobtify.EntityFrameworkCore)
- [Integrate with ASP.NET Core Web API](https://github.com/Valobtify/Valobtify.AspNetCore.WebApi)

---

### Overview

`Valobtify` is a .NET library that simplifies the creation and use of value objects and single-value objects in domain-driven design (DDD). It provides base classes and interfaces for implementing these patterns with validation and atomicity in mind.

---

### Installation

To install the `Valobtify` package, run the following command in your terminal:

```shell
dotnet add package Valobtify
```

Ensure you have the required .NET SDK installed.

---

### Usage

Define a value object by inheriting from `ValueObject` and implementing the `GetAtomicValues` method. This method specifies the components that uniquely identify the value object.

```csharp
public class Price : ValueObject
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }

    public override IEnumerable<object?> GetAtomicValues()
    {
        return new[] { Amount, Currency };
    }
}
```

**Explanation:**

- `Amount` and `Currency` are the components that make the `Price` object unique.
- `GetAtomicValues` ensures that equality comparisons and hashing are based on these components.

---

### Single-Value Objects

Single-value objects represent domain concepts that encapsulate a single scalar value with validation. `Valobtify` simplifies their creation:

```csharp
public sealed class Age : SingleValueObject<Age, int>, ICreatableValueObject<Age, int>
{
    private Age(int value) : base(value) { }

    public static Result<Age> Create(int value)
    {
        if (value < 0) return new ResultError("Age is not valid");

        return new Age(value);
    }
}
```

**Explanation:**

- The `Age` class inherits from `SingleValueObject<Age, int>` to represent a value object with an integer value.
- The `Create` method validates the value before creating an instance of `Age`.
- If the value is invalid, a `ResultError` is returned; otherwise, a valid `Age` object is created.

---

### Integration

#### EF Core

`Valobtify` integrates with EF Core, allowing you to persist value objects in your database easily. [Learn more about EF Core integration](https://github.com/Valobtify/Valobtify.EntityFrameworkCore).

#### ASP.NET Core Web API

Simplify the use of value objects in your ASP.NET Core Web API by leveraging `Valobtify`. [Learn more about ASP.NET Core integration](https://github.com/Valobtify/Valobtify.AspNetCore.WebApi).

