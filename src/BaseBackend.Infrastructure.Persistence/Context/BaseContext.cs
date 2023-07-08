using BaseBackend.Domain;
using BaseBackend.Domain.Basic;
using BaseBackend.Infrastructure.Persistence.Extentions;
using Microsoft.EntityFrameworkCore;

namespace BaseBackend.Infrastructure.Persistence.Context;

public class BaseContext : DbContext
{
    public BaseContext(DbContextOptions<BaseContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.RegisterAllEntities<IEntity>(typeof(Country).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
