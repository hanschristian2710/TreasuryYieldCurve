# Treasury Yield Data & Deposit Term

This project allows users to:

- Fetch treasury yield data from an external API from a given date range (max 90 days date range).
- Plot the treasury yield curve for the amount and terms.
- Submit and simulate deposit orders based on selected treasury rates, terms, and dates.
- View historical deposit order submissions.

Third-party API Data Used: https://site.financialmodelingprep.com/developer/docs/stable/treasury-rates

Compound Calculation: Daily

Chart Explanation
- **X-axis** represents days until maturity 
- **Y-axis** represents growth of the deposited amount

Treasury terms are irregularly spaced, so points on the x-axis are not evenly distributed. They are split on the x-axis as below:
- 1M (7d, 15d, 30d)
- 2M (7d, 15d, 30d, 60d)
- 3M (7d, 15d, 30d, 60d, 90d)
- 6M (7d, 15d, 30d, 60d, 90d, 120d, 150d, 180d)
- 1Y (30d, 60d, 90d, 120d, 150d, 180d, 365d)
- 2Y (30d, 60d, 180d, 365d, 540d, 730d)
- 3Y (60d, 180d, 365d, 540d, 730d, 1095d)
- 5Y (180d, 365d, 540d, 730d, 1095d, 1825d)
- 7Y (365d, 540d, 730d, 1095d, 1460d, 1825d, 2190d, 2555d)
- 10Y (365d, 540d, 730d, 1095d, 1460d, 1825d, 2190d, 2555d, 2920d, 3650d)
- 20Y (365d, 540d, 730d, 1095d, 1460d, 1825d, 2190d, 2555d, 2920d, 3650d, 4380d, 5475d, 6570d, 7300d)
- 30Y (365d, 540d, 730d, 1095d, 1460d, 1825d, 2190d, 2555d, 2920d, 3650d, 4380d, 5475d, 6570d, 7300d, 8395d, 9125d, 10950d)

## Prerequisites

Project is developed in Mac and using VS Code.

Stack:
- Web Framework: Blazor
- C# .NET Core

Before running the project, ensure you have the following installed:
- [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
- [VS Code](https://code.visualstudio.com/) for Mac

VS Code Extensions needed:
- [C# DEV Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

Additional Blazor Doc: [Blazor](https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/install)

## Running project:
Open Terminal:
1. Restore Dependencies (Only needed for first time) `dotnet restore`
2. Build the project `dotnet build`
3. Run the app `dotnet run`

Listening Port: `http://localhost:5028`
Can be updated in `launchSettings.json`

## Demo Video
Download [here](https://drive.google.com/file/d/1pElt379WT3VSRcPix7zOMq7RbxmIwPFC/view?usp=sharing) for the demo video

![Preview](assets/demo.gif)