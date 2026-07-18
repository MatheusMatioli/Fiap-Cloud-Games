namespace FIAP.CloudGames.Api.Contracts.Users;

/// <summary>
/// Dados recebidos para criar um usuário.
/// </summary>
public sealed class RequisicaoCriarUsuario
{
    public string Nome { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;
}
