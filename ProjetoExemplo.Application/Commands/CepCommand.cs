using ProjetoExemplo.Application.Interfaces;
using ProjetoExemplo.Application.Models;
using ProjetoExemplo.Domain.Interfaces.Services;

namespace ProjetoExemplo.Application.Commands;

public class CepCommand : ICepCommand
{
    private readonly ICepService _cepService;

    public CepCommand(ICepService cepService)
    {
        _cepService = cepService;
    }

    public async Task<AddressModel?> GetAddressByCep(string cep)
    {
        var address = await _cepService.GetAddressByCep(cep);

        // Mapeamento do objeto de domínio para o Model, pode ser feito com AutoMapper ou qualquer outra biblioteca também.
        if (address != null)
        {
            var addressModel = new AddressModel
            {
                Bairro = address.Bairro,
                Cep = address.Cep,
                Complemento = address.Complemento,
                Ddd = address.Ddd,
                Gia = address.Gia,
                Ibge = address.Ibge,
                Logradouro = address.Logradouro,
                Siafi = address.Siafi,
                UF = address.UF
            };

            return addressModel;
        }

        return null;
    }
}