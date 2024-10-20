using Newtonsoft.Json;
using System.Net.Http;

public class ExchangeApiClient
{
    private static readonly HttpClient _httpClient = new HttpClient();


    public class MarketPriceResponse
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }
    }

    public async Task<string> GetMarketDataAsync(string symbol)
    {
        var url = $"https://api.binance.com/api/v3/ticker/price?symbol={symbol}";
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();

        // Deserialize the JSON response
        var marketData = JsonConvert.DeserializeObject<MarketPriceResponse>(jsonResponse);

        // Format the output
        return $"{marketData.Symbol}: {marketData.Price:F2}"; // F2 for two decimal places
    }

}