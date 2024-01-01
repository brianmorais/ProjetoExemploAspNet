using AutoMapper;
using ProjetoExemploAspNet.Application;

namespace ProjetoExemploAspNet.Tests.Base;

public class TestBase
{
    public static Mapper SetupAutoMapper()
    {
        var profile = new MappingSetup();
        var configuration = new MapperConfiguration(config => config.AddProfile(profile));
        return new Mapper(configuration);
    }
}
