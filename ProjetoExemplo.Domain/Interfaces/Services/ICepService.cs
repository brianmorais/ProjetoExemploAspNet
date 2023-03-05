using ProjetoExemplo.Domain.ValueObjects;

namespace ProjetoExemplo.Domain.Interfaces.Services;

public interface ICepService
{
    Task<Address?> GetAddressByCep(string cep);
}