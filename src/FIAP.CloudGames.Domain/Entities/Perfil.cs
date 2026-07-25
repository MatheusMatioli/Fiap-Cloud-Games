namespace FiapCloudGames.Domain.Entities;

public class Perfil
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }

    public ICollection<Usuario> Usuarios { get; private set; } = new List<Usuario>();
    public ICollection<Permissao> Permissoes { get; private set; } = new List<Permissao>();

    protected Perfil()
    {
    }

    public Perfil(string nome)
    {
        Id = Guid.NewGuid();
        Nome = nome;
    }
}