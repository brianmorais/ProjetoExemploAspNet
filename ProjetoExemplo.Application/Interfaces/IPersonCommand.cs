using ProjetoExemplo.Application.Models;

namespace ProjetoExemplo.Application.Interfaces;

public interface IPersonCommand
{
    Task<IEnumerable<PersonModel>> GetPersons();
    Task<PersonModel> AddPerson(PersonModel personModel);
}