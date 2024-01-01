using Moq;
using ProjetoExemploAspNet.Application.Commands;
using ProjetoExemploAspNet.Application.Interfaces;
using ProjetoExemploAspNet.Domain.Interfaces.Services;
using ProjetoExemploAspNet.Domain.ValueObjects;
using ProjetoExemploAspNet.Tests.Base;
using ProjetoExemploAspNet.Tests.Mocks;

namespace ProjetoExemploAspNet.Tests.Commands;

public class CepCommandTest : TestBase
{
    private Mock<ICepService> _cepServiceMock = new();

    private ICepCommand GetCepCommand()
    {
        return new CepCommand(_cepServiceMock.Object, SetupAutoMapper());
    }

    [Fact]
    public async Task ShouldGetAddressByCep()
    {
        var cep = "11224466";
        var address = CepMock.GetAddressMock(cep);
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
