using Moq;
using ProjetoExemplo.Application.Commands;
using ProjetoExemplo.Application.Interfaces;
using ProjetoExemplo.Domain.Interfaces.Repositories;
using ProjetoExemplo.Tests.Base;
using ProjetoExemplo.Tests.Mocks;

namespace ProjetoExemplo.Tests.Commands;

public class PersonCommandTest : TestBase
{
    private Mock<IPersonRepository> _personRepositoryMock = new Mock<IPersonRepository>();
    private PersonMock _personMock = new PersonMock();

    private IPersonCommand GetPersonCommand()
    {
        return new PersonCommand(_personRepositoryMock.Object, SetupAutoMapper());
    }

    [Fact]
    public async Task ShouldGetPersons()
    {
        var persons = _personMock.GetPersonsMock();
        _personRepositoryMock.Setup(x => x.GetPersons()).ReturnsAsync(persons);
        var command = GetPersonCommand();

        var result = await command.GetPersons();

        Assert.Equal(persons.Count, result.Count());
        _personRepositoryMock.Verify(x => x.GetPersons(), Times.Once);
    }
}
