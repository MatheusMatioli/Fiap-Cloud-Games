using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FIAP.CloudGames.Domain.Entities;

namespace FIAP.CloudGames.Infrastructure.Data.EF.Mappings;

public class AutorizacaoMapping : IEntityTypeConfiguration<Autorizacao>
{
    public void Configure(EntityTypeBuilder<Autorizacao> builder)
    {
        builder.ToTable("tb_Autorizacao");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Nome)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasOne<Usuario>()
                .WithMany()
                .HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<Jogo>()
                .WithMany();

        builder.HasIndex(x => new { x.UsuarioId, x.JogoId })
            .IsUnique();
    }
}