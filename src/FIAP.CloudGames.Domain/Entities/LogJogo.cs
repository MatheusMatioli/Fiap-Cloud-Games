namespace FIAP.CloudGames.Domain.Entities;

public class LogJogo
{
    public Guid Id { get; private set; }
    public Guid JogoId { get; private set; }
    public string Descricao { get; private set; } = string.Empty;
    public DateTime DataCriacao { get; private set; }
}