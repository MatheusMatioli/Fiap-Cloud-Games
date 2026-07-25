namespace FiapCloudGames.Domain.Entities;

public class Permissao
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string? Descricao { get; private set; }
    public Guid PerfilId { get; private set; }

    public Perfil Perfil { get; private set; }

    protected Permissao()
    {
    }

    public Permissao(string nome, string? descricao, Guid perfilId)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Descricao = descricao;
        PerfilId = perfilId;
    }
}