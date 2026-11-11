namespace TEFWEB.Models;

public class ItemMercadoriaCliente
{
    public Guid ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;
    public int MercadoriaId { get; set; }
    public Mercadoria Mercadoria { get; set; } = null!;
    public decimal Preco { get; set; }
}
