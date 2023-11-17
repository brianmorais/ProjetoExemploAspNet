using ProjetoExemplo.Domain.ValueObjects;

namespace ProjetoExemplo.Tests.Mocks;

public class CepMock
{
    public Address GetAddressMock(string cep = "11224433")
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
}
