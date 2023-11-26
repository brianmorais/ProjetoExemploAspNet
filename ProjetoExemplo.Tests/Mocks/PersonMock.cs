using ProjetoExemplo.Domain.Entities;

namespace ProjetoExemplo.Tests.Mocks;

public class PersonMock
{
    public static List<Person> GetPersonsMock()
    {
        return new List<Person>
        {
            new Person
            {
                Id = 1,
                Name = "Person 1"
            },
            new Person
            {
                Id = 2,
                Name = "Person 2"
            }
        };
    }

    public static Person GetPersonMock()
    {
        return GetPersonsMock().First();
    }
}
