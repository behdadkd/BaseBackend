// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace BaseBackend.Domain;

public interface IEntity<T>
{
    T Id { get; set; }
    bool IsDeleted { get; set; }
}

public abstract class Entity : IEntity<long>
{
    public long Id { get; set; }
    public bool IsDeleted { get; set; }
}

public abstract class Entity<T> : IEntity<T>
{
    public T Id { get; set; } = default!;
    public bool IsDeleted { get; set; }
}