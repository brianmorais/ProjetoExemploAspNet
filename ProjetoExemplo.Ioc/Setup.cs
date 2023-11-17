using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoExemplo.Application;
using ProjetoExemplo.Application.Commands;
using ProjetoExemplo.Application.Interfaces;
using ProjetoExemplo.Data;
using ProjetoExemplo.Data.Repositories;
using ProjetoExemplo.Domain.Interfaces.Repositories;
using ProjetoExemplo.Domain.Interfaces.Services;
using ProjetoExemplo.Services.ViaCep;

namespace ProjetoExemplo.Ioc;

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
