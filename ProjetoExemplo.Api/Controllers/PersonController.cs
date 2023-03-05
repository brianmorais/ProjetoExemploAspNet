using Microsoft.AspNetCore.Mvc;
using ProjetoExemplo.Application.Interfaces;
using ProjetoExemplo.Application.Models;

namespace ProjetoExemplo.Api.Controllers;

[ApiController]
[Route("api/persons")]
public class PersonController : ControllerBase
{
    private IPersonCommand _personCommand;
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger, IPersonCommand personCommand)
    {
        _personCommand = personCommand;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonModel>>> GetPersons()
    {
        try
        {
            var persons = await _personCommand.GetPersons();
            return Ok(persons);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }

    [HttpPost]
    public async Task<ActionResult<PersonModel>> AddPerson([FromBody] PersonModel person)
    {
        try
        {
            var response = await _personCommand.AddPerson(person);
            return Ok(person);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return StatusCode(500);
        }
    }
}
