using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjetoExemplo.Application.Commands;
using ProjetoExemplo.Application.Interfaces;
using ProjetoExemplo.Data.Repositories;
using ProjetoExemplo.Domain.Interfaces;

namespace ProjetoExemplo.Ioc;

public class Setup
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IPersonCommand, PersonCommand>();
    }
}
