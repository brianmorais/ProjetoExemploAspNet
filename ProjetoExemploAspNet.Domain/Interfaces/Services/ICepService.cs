using ProjetoExemploAspNet.Domain.ValueObjects;

namespace ProjetoExemploAspNet.Domain.Interfaces.Services;

public interface ICepService
{
    Task<Address?> GetAddressByCep(string cep);
}