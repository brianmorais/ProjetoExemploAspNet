using Microsoft.AspNetCore.Mvc;
using ProjetoExemplo.Application.Interfaces;
using ProjetoExemplo.Application.Models;

namespace ProjetoExemplo.Api.Controllers;

[ApiController]
[Route("api/cep")]
public class CepController : ControllerBase
{
    private ICepCommand _cepCommand;
    private readonly ILogger<CepController> _logger;

    public CepController(ILogger<CepController> logger, ICepCommand cepCommand)
    {
        _cepCommand = cepCommand;
        _logger = logger;
    }

    [HttpGet("{cep}")]
    public async Task<ActionResult<AddressModel>> GetAddressByCep(string cep)
    {
        try
        {
            var address = await _cepCommand.GetAddressByCep(cep);
            return Ok(address);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }
}
