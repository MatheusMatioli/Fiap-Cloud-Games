namespace FIAP.CloudGames.Infrastructure.Data.EF.Mappings;

internal sealed class MapeamentoUsuario : IEntityTypeConfiguration<Usuario>
{
    public const string NomeIndiceEmailUnico = "ux_usuarios_email";

    public void Configure(EntityTypeBuilder<Usuario> construtor)
    {
        construtor.ToTable("usuarios");

        construtor.HasKey(usuario => usuario.Id)
            .HasName("pk_usuarios");

        construtor.Property(usuario => usuario.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        construtor.Property(usuario => usuario.Nome)
            .HasColumnName("nome")
            .HasMaxLength(Usuario.TamanhoMaximoNome)
            .IsRequired();

        construtor.Property(usuario => usuario.Email)
            .HasColumnName("email")
            .HasMaxLength(Usuario.TamanhoMaximoEmail)
            .IsRequired();

        construtor.Property(usuario => usuario.CriadoEmUtc)
            .HasColumnName("criado_em_utc")
            .HasColumnType("timestamp with time zone")
            .IsRequired();

        construtor.HasIndex(usuario => usuario.Email)
            .IsUnique()
            .HasDatabaseName(NomeIndiceEmailUnico);
    }
}
