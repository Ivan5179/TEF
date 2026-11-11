namespace TEFWEB.Models;

public abstract class Pessoa
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Nome { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}
