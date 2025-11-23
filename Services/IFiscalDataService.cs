using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModernFI.Models;

namespace ModernFI.Services;

public interface IFiscalDataService
{
    Task<TreasuryYieldAPIResponse?> GetAverageInterestRate(DateTime? start, DateTime? end, int pageNumber = 50);
    Task<TreasuryYieldAPIResponse?> GetAverageInterestRateByContinuationLink(string link, DateTime? start, DateTime? end);
}
