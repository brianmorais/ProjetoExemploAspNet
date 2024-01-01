using Moq;
using ProjetoExemploAspNet.Application.Commands;
using ProjetoExemploAspNet.Application.Interfaces;
using ProjetoExemploAspNet.Domain.Interfaces.Repositories;
using ProjetoExemploAspNet.Tests.Base;
using ProjetoExemploAspNet.Tests.Mocks;

namespace ProjetoExemploAspNet.Tests.Commands;

public class PersonCommandTest : TestBase
{
    private Mock<IPersonRepository> _personRepositoryMock = new();

    private IPersonCommand GetPersonCommand()
    {
        return new PersonCommand(_personRepositoryMock.Object, SetupAutoMapper());
    }

    [Fact]
    public async Task ShouldGetPersons()
    {
        var persons = PersonMock.GetPersonsMock();
        _personRepositoryMock.Setup(x => x.GetPersons()).ReturnsAsync(persons);
        var command = GetPersonCommand();

        var result = await command.GetPersons();

        Assert.Equal(persons.Count, result.Count());
        _personRepositoryMock.Verify(x => x.GetPersons(), Times.Once);
    }
}
