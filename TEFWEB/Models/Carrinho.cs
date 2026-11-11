namespace TEFWEB.Models;

public class Carrinho
{
    public int Id { get; set; }
    public Guid ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;
    public int MercadoriaId { get; set; }
    public Mercadoria Mercadoria { get; set; } = null!;
    public decimal Quantidade { get; set; } = 1m;
    public decimal Peso {get; set; } = 1m;
}
