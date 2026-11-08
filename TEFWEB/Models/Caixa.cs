using Microsoft.EntityFrameworkCore;

namespace TEFWEB.Models;

public class Caixa
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}

public class Caixadb : DbContext
{
    public DbSet<Caixa> Caixas => Set<Caixa>();
    public Caixadb(DbContextOptions<Caixadb> options) : base(options) {}
}