using System;

namespace FIAP.CloudGames.Domain.Entities;

public sealed class Permissao
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string? Descricao { get; private set; } = string.Empty;
    public Guid PerfilId { get; private set; }

}
