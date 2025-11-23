using System;
using System.Net.Http;
using System.Net.Http.Json;
using ModernFI.Models;

namespace ModernFI.Services;

public class FiscalDataService : IFiscalDataService
{
    private readonly HttpClient _httpClient;
    private const string _fiscalDataBaseUrl = "https://api.fiscaldata.treasury.gov/services/api/fiscal_service/";
    private enum FiscalDataSet
    {
        AverageInterestRate
    }
    
    public FiscalDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;   
    }

    public async Task<TreasuryYieldAPIResponse?> GetAverageInterestRate(
        DateTime? start = null, 
        DateTime? end = null, 
        int pageSize = 50)
    {
        try
        {
            var dataSet = FiscalDataSet.AverageInterestRate;
            var requestUrl = $"{_fiscalDataBaseUrl}{GetEndpoint(dataSet)}";

            // Query Filter
            var query = new List<string>();

            // Date filter
            if (start.HasValue && end.HasValue)
            {
                string startStr = start.Value.ToString("yyyy-MM-dd");
                string endStr = end.Value.ToString("yyyy-MM-dd");
                query.Add($"record_date:gte:{startStr},record_date:lte:{endStr}");
            }

            // Sort by latest date
            query.Add("sort=-record_date");

            // Page size
            query.Add($"page[size]={pageSize}");

            if (query.Count > 0)
                requestUrl += $"?filter={string.Join("&", query)}";

            var response = await _httpClient.GetFromJsonAsync<TreasuryYieldAPIResponse>(requestUrl);
            if (response is null || response.data is null || response.data.Count <= 0)
                return null;
            
            return response;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to fetch yields data: {ex.Message}");
        }
    }

    public async Task<TreasuryYieldAPIResponse?> GetAverageInterestRateByContinuationLink(
        string link,
        DateTime? start = null, 
        DateTime? end = null)
    {
        try
        {
            var requestUrl = $"{_fiscalDataBaseUrl}{GetEndpoint(FiscalDataSet.AverageInterestRate)}";

            // Query Filter
            var query = new List<string>();

            // Date filter
            if (start.HasValue && end.HasValue)
            {
                string startStr = start.Value.ToString("yyyy-MM-dd");
                string endStr = end.Value.ToString("yyyy-MM-dd");
                query.Add($"record_date:gte:{startStr},record_date:lte:{endStr}");
            }

            query.Add(link);

            if (query.Count > 0)
                requestUrl += $"?filter={string.Join("&", query)}";

            var response = await _httpClient.GetFromJsonAsync<TreasuryYieldAPIResponse>(requestUrl);
            if (response is null || response.data is null || response.data.Count <= 0)
                return null;
            
            return response;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to fetch paginated yields: {ex.Message}");
        }
    }


    #region Utility

    /// <summary>
    /// Helper to get specific endpoints from the dataset
    /// </summary>
    /// <param name="dataset"></param>
    /// <returns></returns>
    private string GetEndpoint(FiscalDataSet dataset)
    {
        switch (dataset)
        {
            case FiscalDataSet.AverageInterestRate:
                return "v2/accounting/od/avg_interest_rates";
            default:
                return string.Empty;
        }
    }

    #endregion
    
}
