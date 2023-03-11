using AutoMapper;
using ProjetoExemplo.Application.Models;
using ProjetoExemplo.Domain.Entities;
using ProjetoExemplo.Domain.ValueObjects;

namespace ProjetoExemplo.Application;

public class MappingSetup : Profile
{
    public MappingSetup()
    {
        CreateMap<Person, PersonModel>().ReverseMap();
        CreateMap<Person[], IEnumerable<PersonModel>>().ReverseMap();

        CreateMap<Address, AddressModel>().ReverseMap();
        CreateMap<Address[], IEnumerable<AddressModel>>().ReverseMap();
    }
}