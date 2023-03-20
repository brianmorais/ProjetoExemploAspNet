using ProjetoExemplo.Domain.Entities;

namespace ProjetoExemplo.Domain.Interfaces.Repositories;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetPersons();
    Task<Person> AddPerson(Person person);
}