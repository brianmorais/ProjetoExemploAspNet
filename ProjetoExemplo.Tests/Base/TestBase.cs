using AutoMapper;
using ProjetoExemplo.Application;

namespace ProjetoExemplo.Tests.Base;

public class TestBase
{
    public Mapper SetupAutoMapper()
    {
        var profile = new MappingSetup();
        var configuration = new MapperConfiguration(config => config.AddProfile(profile));
        return new Mapper(configuration);
    }
}
