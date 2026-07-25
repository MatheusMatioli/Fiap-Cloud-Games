using FIAP.CloudGames.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FIAP.CloudGames.Infrastructure.Data.Mappings;

public class MapeamentoPerfil : IEntityTypeConfiguration<Perfil>
{
    public void Configure(EntityTypeBuilder<Perfil> builder)
    {
        builder.ToTable("tb_Perfil");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .HasColumnType("uuid")
            .IsRequired();

        builder.Property(x => x.Nome)
            .HasColumnName("Nome")
            .HasColumnType("varchar(200)")
            .IsRequired();

        builder.HasIndex(x => x.Nome)
            .IsUnique();

        builder.HasMany(x => x.Usuarios)
            .WithOne(x => x.Perfil)
            .HasForeignKey(x => x.PerfilId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(x => x.Permissoes)
            .WithOne(x => x.Perfil)
            .HasForeignKey(x => x.PerfilId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}