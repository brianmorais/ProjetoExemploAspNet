using ProjetoExemplo.Application.Models;
using ProjetoExemplo.Application.Interfaces;
using ProjetoExemplo.Domain.Entities;
using ProjetoExemplo.Domain.Interfaces.Repositories;

namespace ProjetoExemplo.Application.Commands;

public class PersonCommand : IPersonCommand
{
    private IPersonRepository _personRepository;

    public PersonCommand(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<IEnumerable<PersonModel>> GetPersons()
    {
        var persons = await _personRepository.GetPersons();

        // Mapeamento do objeto de domínio para o Model, pode ser feito com AutoMapper ou qualquer outra biblioteca também.
        var personsModel = new List<PersonModel>();
        foreach (var person in persons)
        {
            personsModel.Add(new PersonModel
            {
                Id = person.Id,
                Name = person.Name
            });
        }

        return personsModel;
    }

    public async Task<PersonModel> AddPerson(PersonModel personModel)
    {
        // Mapeamento do Model para o objeto de domínio, pode ser feito com AutoMapper ou qualquer outra biblioteca também.
        var person = new Person
        {
            Name = personModel.Name
        };

        person = await _personRepository.AddPerson(person);

        // Mapeamento do objeto de domínio para o Model, pode ser feito com AutoMapper ou qualquer outra biblioteca também.
        personModel = new PersonModel
        {
            Id = person.Id,
            Name = person.Name
        };

        return personModel;
    }
}