// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace BaseBackend.Domain;

public interface IEntity<T>
{
    T Id { get; set; }
}
public interface IKnownEntity<T> : IEntity<T>
{
    Guid? CreatedUserId { get; set; }
    DateTime CreatedOn { get; set; }
    Guid? ModifiedUserId { get; set; }
    DateTime? ModifiedOn { get; set; }
}
public interface IDeletableEntity<T> : IEntity<T>
{
    Guid? DeletedUserId { get; set; }
    DateTime? DeletedOn { get; set; }
    bool IsDeleted { get; set; }
}

public interface IFullEntity<T> : IKnownEntity<T>,IDeletableEntity<T>
{
}

public abstract class Entity : IEntity<Guid>
{
    public Guid Id { get; set; }
}

public abstract class Entity<T> : IEntity<T>
{
    public T Id { get; set; } = default!;
}

public abstract class KnownEntity<T> : Entity<T>, IKnownEntity<T>
{
    public Guid? CreatedUserId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid? ModifiedUserId { get; set; }
    public DateTime? ModifiedOn { get; set; }
}

public abstract class DeletableEntity<T> : Entity<T>, IDeletableEntity<T>
{
    public Guid? DeletedUserId { get; set; }
    public DateTime? DeletedOn { get; set; }
    public bool IsDeleted { get; set; }

}

public abstract class FullEntity<T> : Entity<T> , IFullEntity<T>
{
    public Guid? CreatedUserId { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid? ModifiedUserId { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public Guid? DeletedUserId { get; set; }
    public DateTime? DeletedOn { get; set; }
    public bool IsDeleted { get; set; }
}