using ProjetoExemploAspNet.Application.Models;

namespace ProjetoExemploAspNet.Application.Interfaces;

public interface ICepCommand
{
    Task<AddressModel?> GetAddressByCep(string cep);
}