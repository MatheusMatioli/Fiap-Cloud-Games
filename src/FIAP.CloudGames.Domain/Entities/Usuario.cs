namespace FIAP.CloudGames.Domain.Entities;

/// <summary>
/// Representa um usuário persistido pela plataforma.
/// </summary>
public sealed class Usuario
{
    public const int TamanhoMaximoNome = 120;
    public const int TamanhoMaximoEmail = 320;

    private Usuario()
    {
    }

    public Usuario(
        Guid id,
        string nome,
        string email,
        DateTimeOffset criadoEmUtc)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("O identificador do usuário não pode ser vazio.", nameof(id));
        }

        ArgumentException.ThrowIfNullOrWhiteSpace(nome);
        ArgumentException.ThrowIfNullOrWhiteSpace(email);

        if (nome.Length > TamanhoMaximoNome)
        {
            throw new ArgumentOutOfRangeException(nameof(nome));
        }

        if (email.Length > TamanhoMaximoEmail)
        {
            throw new ArgumentOutOfRangeException(nameof(email));
        }

        if (criadoEmUtc.Offset != TimeSpan.Zero)
        {
            throw new ArgumentException("A data de criação deve estar em UTC.", nameof(criadoEmUtc));
        }

        Id = id;
        Nome = nome;
        Email = email;
        CriadoEmUtc = criadoEmUtc;
    }

    public Guid Id { get; private set; }

    public string Nome { get; private set; } = string.Empty;

    public string Email { get; private set; } = string.Empty;

    public DateTimeOffset CriadoEmUtc { get; private set; }
}
