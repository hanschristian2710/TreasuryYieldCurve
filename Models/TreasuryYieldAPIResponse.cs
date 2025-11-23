using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ModernFI.Models;

public class TreasuryYieldAPIResponse
{
    public List<TreasuryYield> data { get; set; } = new();
    public FiscalMeta? meta { get; set; }
    public FiscalLinks? links { get; set; }
}

public class FiscalLinks
{
    public string? self { get; set; }
    public string? first { get; set; }
    public string? prev { get; set; }
    public string? next { get; set; }
    public string? last { get; set; }
}

public class FiscalMeta
{
    public int? count { get; set; }

    [JsonPropertyName("total-pages")]
    public int? totalPages { get; set; }
    
    [JsonPropertyName("total-count")]
    public int? totalCount { get; set; }
}