using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BaseBackend.Infrastructure.Persistence.Extentions;
public static class ModelBuilderExtentions
{
    /// <summary>
    /// Dynamicaly register all Entities that inherit from specific BaseType
    /// </summary>
    /// <param name="modelBuilder"></param>
    /// <param name="baseType">Base type that Entities inherit from this</param>
    /// <param name="assemblies">Assemblies contains Entities</param>
    public static void RegisterAllEntities<BaseType>(this ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
        IEnumerable<Type> types = assemblies
            .SelectMany(a => a.GetExportedTypes())
            .Where(c => c.IsClass && !c.IsAbstract && c.IsPublic && typeof(BaseType)
            .IsAssignableFrom(c));

        foreach (Type type in types)
            modelBuilder.Entity(type);
    }
}
