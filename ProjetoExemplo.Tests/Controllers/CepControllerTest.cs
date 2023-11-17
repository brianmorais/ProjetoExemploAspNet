using Microsoft.Extensions.Logging;
using Moq;
using ProjetoExemplo.Api.Controllers;
using ProjetoExemplo.Application.Interfaces;
using ProjetoExemplo.Tests.Base;
using ProjetoExemplo.Tests.Mocks;

namespace ProjetoExemplo.Tests.Controllers;

public class CepControllerTest : TestBase
{
    private Mock<ICepCommand> _cepCommandMock = new Mock<ICepCommand>();
    private Mock<ILogger<CepController>> _loggerMock = new Mock<ILogger<CepController>>();
    private CepMock _cepMock = new CepMock();

    private CepController GetCepController()
    {
        return new CepController(_loggerMock.Object, _cepCommandMock.Object);
    }
        
    [Fact]
    public async Task ShouldGetAddressByCep()
    {
        var cep = "11224433";
        var address = _cepMock.GetAddressModelMock(cep);
        _cepCommandMock.Setup(x => x.GetAddressByCep(cep)).ReturnsAsync(address);

        var controller = GetCepController();
        await controller.GetAddressByCep(cep);

        _cepCommandMock.Verify(x => x.GetAddressByCep(cep), Times.Once);
    }
}
