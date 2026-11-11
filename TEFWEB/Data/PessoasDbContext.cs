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
    public DbSet<ItemMercadoriaCliente> ItensMercadoriaCliente => Set<ItemMercadoriaCliente>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pessoa>().UseTpcMappingStrategy();
        modelBuilder.Entity<Pessoa>().Property(pessoa => pessoa.Id).ValueGeneratedNever();
        modelBuilder.Entity<Cliente>().ToTable("Clientes");
        modelBuilder.Entity<Supervisor>().ToTable("Supervisores");
        modelBuilder.Entity<Caixa>().ToTable("Caixas");

        modelBuilder.Entity<ItemMercadoriaCliente>()
            .HasKey(item => new { item.ClienteId, item.MercadoriaId });

        modelBuilder.Entity<ItemMercadoriaCliente>()
            .HasOne(item => item.Cliente)
            .WithMany(cliente => cliente.ItensMercadoriaCliente)
            .HasForeignKey(item => item.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ItemMercadoriaCliente>()
            .HasOne(item => item.Mercadoria)
            .WithMany(mercadoria => mercadoria.ItensClientes)
            .HasForeignKey(item => item.MercadoriaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
