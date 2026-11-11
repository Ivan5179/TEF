using TEFWEB.Models;

namespace TEFWEB.Services;

public interface IPessoaService
{
    Task<List<PessoaResumoDto>> RetornarPessoasAsync(CancellationToken cancellationToken);
}
