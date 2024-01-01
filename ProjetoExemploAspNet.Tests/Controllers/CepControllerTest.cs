using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProjetoExemploAspNet.Api.Controllers;
using ProjetoExemploAspNet.Application.Interfaces;
using ProjetoExemploAspNet.Application.Models;
using ProjetoExemploAspNet.Tests.Base;
using ProjetoExemploAspNet.Tests.Mocks;

namespace ProjetoExemploAspNet.Tests.Controllers;

public class CepControllerTest : TestBase
{
    private Mock<ICepCommand> _cepCommandMock = new();
    private Mock<ILogger<CepController>> _loggerMock = new();

    private CepController GetCepController()
    {
        return new CepController(_loggerMock.Object, _cepCommandMock.Object);
    }
        
    [Fact]
    public async Task ShouldGetAddressByCep()
    {
        var cep = "11224433";
        var address = CepMock.GetAddressModelMock(cep);
        _cepCommandMock.Setup(x => x.GetAddressByCep(cep)).ReturnsAsync(address);
        var controller = GetCepController();

        var result = await controller.GetAddressByCep(cep);

        Assert.IsType<ActionResult<AddressModel>>(result);
        _cepCommandMock.Verify(x => x.GetAddressByCep(cep), Times.Once);
    }
}
