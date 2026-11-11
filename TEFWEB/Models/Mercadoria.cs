namespace TEFWEB.Models;

public class Mercadoria
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public ICollection<Carrinho> Carrinhos { get; set; } = new List<Carrinho>();
}