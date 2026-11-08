using Microsoft.EntityFrameworkCore;

namespace TEFWEB.Models;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}

public class Clientedb : DbContext
{
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public Clientedb(DbContextOptions<Clientedb> options) : base(options) {}
}