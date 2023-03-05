using ProjetoExemplo.Domain.Entities;
using ProjetoExemplo.Domain.Interfaces.Repositories;

namespace ProjetoExemplo.Data.Repositories;

public class PersonRepository : IPersonRepository
{
    // Faz a leitura no banco utilizando Entity Framework, Dapper, ADO.NET ou de qualquer outra forma que preferir.
    public async Task<IEnumerable<Person>> GetPersons()
    {
        // Simulando um processo assíncrono.
        await Task.CompletedTask;
        return new List<Person>();
    }

    // Faz a inserção no banco utilizando Entity Framework, Dapper, ADO.NET ou de qualquer outra forma que preferir.
    public async Task<Person> AddPerson(Person person)
    {
        // Simulando um processo assíncrono.
        await Task.CompletedTask;
        return person;
    }
}
