using Microsoft.EntityFrameworkCore;
using TEFWEB.Data;
using TEFWEB.Models;

namespace TEFWEB.Services;

public class PessoaService : IPessoaService
{
    private readonly PessoasDbContext _dbContext;

    public PessoaService(PessoasDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<PessoaResumoDto>> RetornarPessoasAsync(CancellationToken cancellationToken)
    {
        var pessoas = await _dbContext.Pessoas
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return pessoas.Select(pessoa => new PessoaResumoDto(
            pessoa.Senha,
            pessoa switch
            {
                Cliente => "Cliente",
                Supervisor => "Supervisor",
                Caixa => "Caixa",
                _ => throw new InvalidOperationException(
                    $"Tipo de pessoa não suportado: {pessoa.GetType().Name}")
            })).ToList();
    }
}