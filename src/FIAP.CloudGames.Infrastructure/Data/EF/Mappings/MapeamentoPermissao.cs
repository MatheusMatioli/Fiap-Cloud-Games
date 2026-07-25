using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FIAP.CloudGames.Domain.Entities;

namespace FIAP.CloudGames.Infrastructure.Data.EF.Mappings;

internal sealed class MapeamentoPermissao : IEntityTypeConfiguration<Permissao>
{
    public void Configure(EntityTypeBuilder<Permissao> construtor)
    {
        construtor.ToTable("permissoes");

        construtor.HasKey(permissao => new { permissao.Id, permissao.PerfilId })
            .HasName("pk_permissoes");

        construtor.Property(permissao => permissao.Id)
            .HasColumnName("id");

        construtor.Property(permissao => permissao.PerfilId)
            .HasColumnName("perfil_id");

        construtor.Property(permissao => permissao.Nome)
            .HasColumnName("nome")
            .HasMaxLength(200)
            .IsRequired();

        construtor.Property(permissao => permissao.Descricao)
            .HasColumnName("descricao")
            .HasMaxLength(200)
            .IsRequired(false);
    }
}
