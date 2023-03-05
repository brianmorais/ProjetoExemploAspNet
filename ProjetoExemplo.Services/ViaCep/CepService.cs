using System.Text.Json;
using ProjetoExemplo.Domain.Interfaces.Services;
using ProjetoExemplo.Domain.ValueObjects;

namespace ProjetoExemplo.Services.ViaCep;

public class CepService : ICepService
{
    private readonly HttpClient _httpClient;
    private readonly string _basePath = "/ws/{cep}/json";

    public CepService(HttpClient httpClient)
    {
        _httpClient = httpClient;   
    }

    public async Task<Address?> GetAddressByCep(string cep)
    {
        var response = await _httpClient.GetAsync(_basePath.Replace("{cep}", cep));
        if (response.IsSuccessStatusCode)
        {
            var address = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Address>(address, new JsonSerializerOptions
            { 
                PropertyNameCaseInsensitive = true
            });
        }

        return null;
    }
}