using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModernFI.Models;
using static ModernFI.Services.TreasuryDataService;

namespace ModernFI.Services;

public interface ITreasuryDataService
{
    Task<List<TreasuryYield>> GetTreasuryRates(
        DateTime? start = null, 
        DateTime? end = null,
        int pageSize = 50);
}
