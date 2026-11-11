using Microsoft.AspNetCore.Mvc;
using TEFWEB.Models;
using TEFWEB.Services;

namespace TEFWEB.Controllers;

[ApiController]
[Route("api/Pessoas")]

public class PessoaController : ControllerBase
{
    private readonly IPessoaService _pessoaService;

    public PessoaController(IPessoaService pessoaService)
    {
        _pessoaService = pessoaService;
    }

    [HttpGet]
    public async Task<ActionResult<List<PessoaResumoDto>>> GetPessoas(
        CancellationToken cancellationToken)
    {
        return await _pessoaService.RetornarPessoasAsync(cancellationToken);
    }
}