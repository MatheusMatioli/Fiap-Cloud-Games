using System;

namespace FIAP.CloudGames.Domain.Entities;

public sealed class Aquisicao
{
    public Guid Id { get; private set; }
    public Guid UsuarioId { get; private set; }
    public Guid JogoId { get; private set; }
    public DateTimeOffset DataAquisicao { get; private set; }
}
