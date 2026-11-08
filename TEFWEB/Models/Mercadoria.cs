using Microsoft.EntityFrameworkCore;

namespace TEFWEB.Models;

public class Mercadoria
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Preco { get; set; }
}

public class Mercadoriadb : DbContext
{
    public DbSet<Mercadoria> Mercadorias => Set<Mercadoria>();
    public Mercadoriadb(DbContextOptions<Mercadoriadb> options) : base(options) {}
}