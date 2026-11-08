using Microsoft.EntityFrameworkCore;

namespace TEFWEB.Models;

public class Supervisor
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
}

public class Supervisordb : DbContext
{
    public DbSet<Supervisor> Supervisores => Set<Supervisor>();
    public Supervisordb(DbContextOptions<Supervisordb> options) : base(options) {}
}