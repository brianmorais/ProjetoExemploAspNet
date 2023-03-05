using ProjetoExemplo.Application.Models;

namespace ProjetoExemplo.Application.Interfaces;

public interface ICepCommand
{
    Task<AddressModel?> GetAddressByCep(string cep);
}