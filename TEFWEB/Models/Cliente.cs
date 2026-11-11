namespace TEFWEB.Models;

public class Cliente : Pessoa
{
    public ICollection<ItemMercadoriaCliente> ItensMercadoriaCliente { get; set; } = new List<ItemMercadoriaCliente>();
}