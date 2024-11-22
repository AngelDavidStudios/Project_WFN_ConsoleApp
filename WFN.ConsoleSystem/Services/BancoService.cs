using RestSharp;
using WFN.Models.Models;

namespace WFN.ConsoleSystem.Services;

public class BancoService
{
    private readonly RestClient _client;
    
    public BancoService()
    {
        _client = new RestClient("http://localhost:5007/api/");
    }
    
    public async Task<List<Entity_Banco>> GetBancos()
    {
        var request = new RestRequest("Banco", Method.Get);
        var response = await _client.ExecuteAsync<List<Entity_Banco>>(request);
        return response.Data;
    }
    
    public async Task<Entity_Banco> GetBanco(int id)
    {
        var request = new RestRequest($"Banco/{id}", Method.Get);
        var response = await _client.ExecuteAsync<Entity_Banco>(request);
        return response.Data;
    }
    
    public async Task AddBanco(Entity_Banco banco)
    {
        var request = new RestRequest("Banco", Method.Post);
        request.AddJsonBody(banco);
        var response = await _client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new System.Exception(response.ErrorMessage);
    }
    
    public async Task UpdateBanco(Entity_Banco banco)
    {
        var request = new RestRequest("Banco", Method.Put);
        request.AddJsonBody(banco);
        var response = await _client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new System.Exception(response.ErrorMessage);
    }
    
    public async Task DeleteBanco(int id)
    {
        var request = new RestRequest($"Banco/{id}", Method.Delete);
        var response = await _client.ExecuteAsync(request);

        if (!response.IsSuccessful)
            throw new System.Exception(response.ErrorMessage);
    }
}