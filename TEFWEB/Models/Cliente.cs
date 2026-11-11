namespace TEFWEB.Models;

public class Cliente : Pessoa
{
    public ICollection<Carrinho> Carrinhos { get; set; } = new List<Carrinho>();
}