using Microsoft.EntityFrameworkCore;
using TEFWEB.Data;
using TEFWEB.Services;
using Microsoft.OpenApi;

namespace TEFWEB;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var conexão = builder.Configuration.GetConnectionString("Pessoas")
            ?? throw new InvalidOperationException("A connection string 'Pessoas' não foi configurada.");

        builder.Services.AddDbContext<PessoasDbContext>(options =>
            options.UseSqlite(conexão));

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddScoped<IPessoaService, PessoaService>();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("V1", new OpenApiInfo
            {
                Title = "API Pessoas",
                Description = "API para gerenciamento de um TEFWEB",
                Version = "V1"
            });
        });

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/V1/swagger.json", "API Pessoas V1");
            });
        }

        app.MapControllers();

        app.Run();
    }
}