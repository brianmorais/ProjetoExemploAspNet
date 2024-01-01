using ProjetoExemploAspNet.Domain.Entities;

namespace ProjetoExemploAspNet.Domain.Interfaces.Repositories;

public interface IPersonRepository
{
    Task<IEnumerable<Person>> GetPersons();
    Task<Person> AddPerson(Person person);
}