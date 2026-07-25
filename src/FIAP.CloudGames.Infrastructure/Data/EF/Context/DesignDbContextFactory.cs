using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using FIAP.CloudGames.Infrastructure.Data.EF.Context;

namespace FIAP.CloudGames.Infrastructure;

public class DesignDbContextFactory : IDesignTimeDbContextFactory<PostgresqlDbContext>
{
    public PostgresqlDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PostgresqlDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Database=dummy;Username=postgres;Password=postgres");
        return new PostgresqlDbContext(optionsBuilder.Options);
    }
}
