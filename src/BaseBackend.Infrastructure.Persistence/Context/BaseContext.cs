using BaseBackend.Domian;
using Microsoft.EntityFrameworkCore;

namespace BaseBackend.Infrastructure.Persistence.Context;

public class BaseContext : DbContext
{
    public DbSet<FirstEntity> FirstEntities { get; set; }

    public BaseContext(DbContextOptions<BaseContext> options) : base(options)
    {
    }
}
