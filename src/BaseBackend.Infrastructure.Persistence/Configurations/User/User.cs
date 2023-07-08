// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Ava.Domain;
using BaseBackend.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ava.Infrastructure.Presistence.Configurations.Authentication;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User), SubSystems.Authentication);

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
               .ValueGeneratedNever();

        builder.Property(x => x.Code)
               .ValueGeneratedOnAdd();

        builder.Property(x => x.PasswordHash)
               .IsRequired();

        builder.Property(x => x.PhoneNumber)
               .IsRequired()
               .IsUnicode()
               .HasMaxLength(11);

        builder.Ignore(x => x.FullName);

        builder.HasIndex(x => x.UserName).IsUnique();
        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.PhoneNumber).IsUnique();
    }
}

