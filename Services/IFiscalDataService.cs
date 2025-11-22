using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModernFI.Models;

namespace ModernFI.Services;

public interface IFiscalDataService
{
    Task<List<TreasuryYield>> GetAverageInterestRate();
}
