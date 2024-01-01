using AutoMapper;
using ProjetoExemploAspNet.Application.Interfaces;
using ProjetoExemploAspNet.Application.Models;
using ProjetoExemploAspNet.Domain.Interfaces.Services;

namespace ProjetoExemploAspNet.Application.Commands;

public class CepCommand : ICepCommand
{
    private readonly ICepService _cepService;
    private readonly IMapper _mapper;

    public CepCommand(ICepService cepService, IMapper mapper)
    {
        _cepService = cepService;
        _mapper = mapper;
    }

    public async Task<AddressModel?> GetAddressByCep(string cep)
    {
        var address = await _cepService.GetAddressByCep(cep);

        if (address != null)
        {
            var addressModel = _mapper.Map<AddressModel>(address);
            return addressModel;
        }

        return null;
    }
}