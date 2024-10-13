using System;
using System.Net.Http;
using System.Threading.Tasks;

public class ExchangeApiClient
{
    private static readonly HttpClient _httpClient = new HttpClient();

    // Method to get market price for a given symbol
    public async Task<string> GetMarketDataAsync(string symbol)
    {
        var url = $"https://api.binance.com/api/v3/ticker/price?symbol={symbol}";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}