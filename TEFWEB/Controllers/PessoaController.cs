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
    public async Task<ActionResult<List<TodasPessoas>>> GetPessoas(
        CancellationToken cancellationToken)
    {
        return await _pessoaService.RetornarPessoasAsync(cancellationToken);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PessoaEspecifica>> RetornarPorId(Guid id, CancellationToken cancellationToken)
    {
        var pessoa = await _pessoaService.RetornarPorIdAsync(id, cancellationToken);

        if (pessoa == null) return NotFound();

        return Ok(pessoa);
    }
}