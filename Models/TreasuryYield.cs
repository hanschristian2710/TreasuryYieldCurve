using System;
using System.Text.Json.Serialization;

namespace ModernFI.Models;

// Sample Response
// {
//     "record_date": "2001-01-31",
//     "security_type_desc": "Marketable",
//     "security_desc": "Treasury Notes",
//     "avg_interest_rate_amt": "6.096",
//     "src_line_nbr": "2",
//     "record_fiscal_year": "2001",
//     "record_fiscal_quarter": "2",
//     "record_calendar_year": "2001",
//     "record_calendar_quarter": "1",
//     "record_calendar_month": "01",
//     "record_calendar_day": "31"
// },
public class TreasuryYield
{
    [JsonPropertyName("record_date")]
    public DateTime? RecordDate { get; set; }

    [JsonPropertyName("security_type_desc")]
    public string? SecurityTypeDesc { get; set; }

    [JsonPropertyName("security_desc")]
    public string? SecurityDesc { get; set; }

    [JsonPropertyName("avg_interest_rate_amt")]
    public decimal? AvgInterestRateAmt { get; set; }

    [JsonPropertyName("src_line_nbr")]
    public int? SrcLineNbr { get; set; }

    [JsonPropertyName("record_fiscal_year")]
    public int? RecordFiscalYear { get; set; }

    [JsonPropertyName("record_fiscal_quarter")]
    public int? RecordFiscalQuarter { get; set; }

    [JsonPropertyName("record_calendar_year")]
    public int? RecordCalendarYear { get; set; }

    [JsonPropertyName("record_calendar_quarter")]
    public int? RecordCalendarQuarter { get; set; }

    [JsonPropertyName("record_calendar_month")]
    public int? RecordCalendarMonth { get; set; }

    [JsonPropertyName("record_calendar_day")]
    public int? RecordCalendarDay { get; set; }
}
