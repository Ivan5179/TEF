using Microsoft.EntityFrameworkCore;
using TEFWEB.Models;

namespace TEFWEB.Data;

public class PessoasDbContext(DbContextOptions<PessoasDbContext> options) : DbContext(options)
{
    public DbSet<Pessoa> Pessoas => Set<Pessoa>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Supervisor> Supervisores => Set<Supervisor>();
    public DbSet<Caixa> Caixas => Set<Caixa>();
    public DbSet<Mercadoria> Mercadorias => Set<Mercadoria>();
    public DbSet<Carrinho> Carrinhos => Set<Carrinho>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pessoa>().UseTpcMappingStrategy();
        modelBuilder.Entity<Pessoa>().Property(pessoa => pessoa.Id).ValueGeneratedNever();
        modelBuilder.Entity<Cliente>().ToTable("Clientes");
        modelBuilder.Entity<Supervisor>().ToTable("Supervisores");
        modelBuilder.Entity<Caixa>().ToTable("Caixas");

        modelBuilder.Entity<Carrinho>()
            .HasOne(carrinho => carrinho.Cliente)
            .WithMany(cliente => cliente.Carrinhos)
            .HasForeignKey(carrinho => carrinho.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Carrinho>()
            .HasOne(carrinho => carrinho.Mercadoria)
            .WithMany(mercadoria => mercadoria.Carrinhos)
            .HasForeignKey(carrinho => carrinho.MercadoriaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
