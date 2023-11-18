using Moq;
using ProjetoExemplo.Application.Commands;
using ProjetoExemplo.Application.Interfaces;
using ProjetoExemplo.Domain.Interfaces.Services;
using ProjetoExemplo.Domain.ValueObjects;
using ProjetoExemplo.Tests.Base;
using ProjetoExemplo.Tests.Mocks;

namespace ProjetoExemplo.Tests.Commands;

public class CepCommandTest : TestBase
{
    private Mock<ICepService> _cepServiceMock = new Mock<ICepService>();
    private CepMock _cepMock = new CepMock();

    private ICepCommand GetCepCommand()
    {
        return new CepCommand(_cepServiceMock.Object, SetupAutoMapper());
    }

    [Fact]
    public async Task ShouldGetAddressByCep()
    {
        var cep = "11224466";
        var address = _cepMock.GetAddressMock(cep);
        _cepServiceMock.Setup(x => x.GetAddressByCep(cep)).ReturnsAsync(address);
        var service = GetCepCommand();

        var result = await service.GetAddressByCep(cep);

        Assert.Equal(cep, result?.Cep);        
    }

    [Fact]
    public async Task ShouldNotGetAddressByCep()
    {
        var cep = string.Empty;
        Address? address = null;
        _cepServiceMock.Setup(x => x.GetAddressByCep(cep)).ReturnsAsync(address);
        var service = GetCepCommand();

        var result = await service.GetAddressByCep(cep);

        Assert.Null(result);
    }
}
