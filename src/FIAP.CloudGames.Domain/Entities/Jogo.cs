using System;

namespace FIAP.CloudGames.Domain.Entities;

public sealed class Jogo
{
    public Guid Id { get; private set; }
    public string Titulo { get; private set; } = string.Empty;
    public string? Descricao { get; private set; } = string.Empty;
    public string? FaixaEtaria { get; private set; } = string.Empty;
    public decimal Preco { get; private set; }
    public bool Ativo { get; private set; }
    public DateTimeOffset DataCadastro { get; private set; }
}
