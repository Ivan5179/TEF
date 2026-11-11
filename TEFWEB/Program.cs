using Microsoft.EntityFrameworkCore;
using TEFWEB.Data;
using TEFWEB.Services;

namespace TEFWEB;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        var connectionString = builder.Configuration.GetConnectionString("Pessoas")
            ?? throw new InvalidOperationException(
                "A connection string 'Pessoas' não foi configurada.");

        builder.Services.AddDbContext<PessoasDbContext>(options =>
            options.UseSqlite(connectionString));
        builder.Services.AddScoped<IPessoaService, PessoaService>();

        var app = builder.Build();

        app.MapControllers();

        app.Run();
    }
}