using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoExemploAspNet.Application;
using ProjetoExemploAspNet.Application.Commands;
using ProjetoExemploAspNet.Application.Interfaces;
using ProjetoExemploAspNet.Data;
using ProjetoExemploAspNet.Data.Repositories;
using ProjetoExemploAspNet.Domain.Interfaces.Repositories;
using ProjetoExemploAspNet.Domain.Interfaces.Services;
using ProjetoExemploAspNet.Services.ViaCep;

namespace ProjetoExemploAspNet.Ioc;

public static class Setup
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("InMemory"));

        services.AddAutoMapper(typeof(MappingSetup));

        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IPersonCommand, PersonCommand>();
        services.AddScoped<ICepCommand, CepCommand>();

        var viaCepUrl = configuration["ServiceUrls:ViaCep"] ?? string.Empty;
        services.AddHttpClient<ICepService, CepService>(options =>
            options.BaseAddress = new Uri(viaCepUrl));
    }
}
