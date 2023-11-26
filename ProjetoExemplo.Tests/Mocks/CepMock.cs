using ProjetoExemplo.Application.Models;
using ProjetoExemplo.Domain.ValueObjects;

namespace ProjetoExemplo.Tests.Mocks;

public class CepMock
{
    public static Address GetAddressMock(string cep = "11224433")
    {
        return new Address
        {
            Bairro = "JD XPTO",
            Cep = cep,
            Complemento = "Complemento XPTO",
            Ddd = "10",
            Gia = string.Empty,
            Ibge = string.Empty,
            Logradouro = "Rua",
            Siafi = string.Empty,
            UF = "SP"
        };
    }

    public static AddressModel GetAddressModelMock(string cep = "11224433")
    {
        return new AddressModel
        {
            Bairro = "JD XPTO",
            Cep = cep,
            Complemento = "Complemento XPTO",
            Ddd = "10",
            Gia = string.Empty,
            Ibge = string.Empty,
            Logradouro = "Rua",
            Siafi = string.Empty,
            UF = "SP"
        };
    }
}
