using System;
using System.Net.Http;
using System.Net.Http.Json;
using ModernFI.Models;

namespace ModernFI.Services;

public class TreasuryDataService : ITreasuryDataService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _treasuryRatesUrl;
    
    public TreasuryDataService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _treasuryRatesUrl = config.GetValue<string>("TreasuryDataService:BaseURL") ?? throw new InvalidOperationException("Data Service URL is not available.");
        _apiKey = config.GetValue<string>("TreasuryDataService:ApiKey") ?? throw new InvalidOperationException("API key is not available.");
    }

    private string GetApiKey() => _apiKey;
    private string GetAPIBaseURL() => _treasuryRatesUrl;

    public async Task<List<TreasuryYield>> GetTreasuryRates(
        DateTime? start = null, 
        DateTime? end = null,
        int pageSize = 50)
    {
        try
        {
            var query = BuildFilters(start, end);
            query.Add($"apikey={GetApiKey()}");

            var queryStr = "";
            if (query.Count > 0)
                queryStr = string.Join("&", query);

            var requestUrl = $"{GetAPIBaseURL()}?{queryStr}";
            var response = await _httpClient.GetFromJsonAsync<List<TreasuryYield>>(requestUrl);
            if (response is null || response.Count <= 0)
                return new List<TreasuryYield>();
            
            return response;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to fetch treasury rates data: {ex.Message}");
        }
    }

    private List<string> BuildFilters(
        DateTime? start, 
        DateTime? end)
    {
        var query = new List<string>();

        // Date filter
        if (start.HasValue)
        {
            string startStr = start.Value.ToString("yyyy-MM-dd");
            query.Add($"from={startStr}");
        }
        else
        {
            // API limitation: 90 days date range
            string startStr = DateTime.Now.Date.AddDays(-90).ToString("yyyy-MM-dd");
            query.Add($"from={startStr}");
        }

        if (end.HasValue)
        {
            string endStr = end.Value.ToString("yyyy-MM-dd");
            query.Add($"to={endStr}");
        }

        return query;
    }
}
