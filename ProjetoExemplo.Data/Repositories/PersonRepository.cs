using ProjetoExemplo.Domain.Entities;
using ProjetoExemplo.Domain.Interfaces;

namespace ProjetoExemplo.Data.Repositories;

public class PersonRepository : IPersonRepository
{
    public async Task<IEnumerable<Person>> GetPersons()
    {
        // Faz a leitura no banco utilizando Entity Framework, Dapper, ADO.NET ou de qualquer outra forma que preferir.
        await Task.CompletedTask;
        return new List<Person>();
    }

    public async Task<Person> AddPerson(Person person)
    {
        // Faz a inserção no banco utilizando Entity Framework, Dapper, ADO.NET ou de qualquer outra forma que preferir.
        await Task.CompletedTask;
        return person;
    }
}
