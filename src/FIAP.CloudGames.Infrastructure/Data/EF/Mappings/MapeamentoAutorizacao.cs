using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

        builder.HasOne(x => x.Usuario)
            .WithMany(x => x.Autorizacoes)
            .HasForeignKey(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Jogo)
            .WithMany(x => x.Autorizacoes)
            .HasForeignKey(x => x.JogoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new { x.UsuarioId, x.JogoId })
            .IsUnique();
    }
}