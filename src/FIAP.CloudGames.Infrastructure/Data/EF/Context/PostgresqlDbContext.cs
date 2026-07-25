using Microsoft.EntityFrameworkCore;
using FIAP.CloudGames.Domain.Entities;

namespace FIAP.CloudGames.Infrastructure.Data.EF.Context;

/// <summary>
/// Unidade de trabalho do Entity Framework Core para o PostgreSQL da aplicação.
/// </summary>
public sealed class PostgresqlDbContext : DbContext
{
    public PostgresqlDbContext(
        DbContextOptions<PostgresqlDbContext> opcoes)
        : base(opcoes)
    {
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresqlDbContext).Assembly);
    }
}
