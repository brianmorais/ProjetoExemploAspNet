using Microsoft.AspNetCore.Mvc;
using ProjetoExemploAspNet.Application.Interfaces;
using ProjetoExemploAspNet.Application.Models;

namespace ProjetoExemploAspNet.Api.Controllers;

[ApiController]
[Route("api/cep")]
public class CepController : ControllerBase
{
    private readonly ICepCommand _cepCommand;
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
            _logger.LogError(ex, "Error on get addres by CPF");
            return StatusCode(500);
        }
    }
}
