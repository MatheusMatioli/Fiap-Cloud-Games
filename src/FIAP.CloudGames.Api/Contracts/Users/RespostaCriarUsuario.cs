namespace FIAP.CloudGames.Api.Contracts.Users;

public sealed record RespostaCriarUsuario(
    Guid Id,
    string Nome,
    string Email,
    DateTimeOffset DataCriacao);
