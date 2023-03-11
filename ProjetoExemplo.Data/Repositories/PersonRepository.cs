using Microsoft.EntityFrameworkCore;
using ProjetoExemplo.Domain.Entities;
using ProjetoExemplo.Domain.Interfaces.Repositories;

namespace ProjetoExemplo.Data.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly ApplicationDbContext _dbContext;
    public PersonRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Person>> GetPersons()
    {
        return await _dbContext.Persons.ToListAsync();
    }

    public async Task<Person> AddPerson(Person person)
    {
        await _dbContext.AddAsync(person);
        await _dbContext.SaveChangesAsync();
        return person;
    }
}
