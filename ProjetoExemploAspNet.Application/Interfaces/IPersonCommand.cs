using ProjetoExemploAspNet.Application.Models;

namespace ProjetoExemploAspNet.Application.Interfaces;

public interface IPersonCommand
{
    Task<IEnumerable<PersonModel>> GetPersons();
    Task<PersonModel> AddPerson(PersonModel personModel);
}