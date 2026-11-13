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

    public async Task<List<TodasPessoas>> RetornarPessoasAsync(CancellationToken cancellationToken)
    {
        var pessoas = await _dbContext.Pessoas
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return pessoas.Select(pessoa => new TodasPessoas(
            pessoa.Id,
            pessoa.Nome,
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

    public async Task<PessoaEspecifica?> RetornarPorIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var pessoa = await _dbContext.Pessoas
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (pessoa == null)
            return null;

        return new PessoaEspecifica(
            pessoa.Id,
            pessoa.Nome,
            pessoa.Senha,
            pessoa switch
            {
                Cliente => "Cliente",
                Supervisor => "Supervisor",
                Caixa => "Caixa",
                _ => throw new InvalidOperationException(
                    $"Tipo de pessoa não suportado: {pessoa.GetType().Name}")
            });
    }
}