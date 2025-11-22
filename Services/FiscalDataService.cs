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
        this._httpClient = httpClient;   
    }

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

    /// <summary>
    /// Request average interest rate
    /// </summary>
    /// <returns>Collections of treasury yield information</returns>
    public async Task<List<TreasuryYield>> GetAverageInterestRate()
    {
        try
        {
            // Invoke the fiscal data api for interest rate
            var requestUrl = $"{_fiscalDataBaseUrl}{GetEndpoint(FiscalDataSet.AverageInterestRate)}";
            var response = await _httpClient.GetFromJsonAsync<TreasuryYieldAPIResponse>(requestUrl);
            if (response is null || response.data is null || response.data.Count <= 0)
                return new List<TreasuryYield>();
            
            return response.data;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
