using AutoMapper;
using ProjetoExemploAspNet.Application.Models;
using ProjetoExemploAspNet.Domain.Entities;
using ProjetoExemploAspNet.Domain.ValueObjects;

namespace ProjetoExemploAspNet.Application;

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