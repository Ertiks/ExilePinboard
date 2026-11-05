using System.Reflection;
using Exile_Pinboard.Application.Common.Interfaces;
using Exile_Pinboard.Domain.Entities;
using Exile_Pinboard.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exile_Pinboard.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<WidgetDefinition> WidgetDefinitions => Set<WidgetDefinition>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Pour éviter les tables inutiles du template
    }
}
