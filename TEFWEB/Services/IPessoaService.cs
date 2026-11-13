using TEFWEB.Models;

namespace TEFWEB.Services;

public interface IPessoaService
{
    Task<List<TodasPessoas>> RetornarPessoasAsync(CancellationToken cancellationToken);

    Task<PessoaEspecifica?> RetornarPorIdAsync(Guid id, CancellationToken cancellationToken);
}

