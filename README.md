Take Home Prompt: You are working with a bank that needs to manage its liquidity. Build a simple full stack application that:
- Pulls data on treasury yields
- Plots the yield curve back to the user
- Allows the user to submit an order for a specific term and amount
- Displays the user’s historical order submissions

API Resources: https://fiscaldata.treasury.gov/api-documentation/#list-of-endpoints
API Endpoint (Treasury Yields): https://api.fiscaldata.treasury.gov/services/api/fiscal_service/v2/accounting/od/avg_interest_rates

Sample response:
{
  "data": [
    {
      "record_date": "2001-01-31",
      "security_type_desc": "Marketable",
      "security_desc": "Treasury Notes",
      "avg_interest_rate_amt": "6.096",
      "src_line_nbr": "2",
      "record_fiscal_year": "2001",
      "record_fiscal_quarter": "2",
      "record_calendar_year": "2001",
      "record_calendar_quarter": "1",
      "record_calendar_month": "01",
      "record_calendar_day": "31"
    },
    {
      "record_date": "2001-01-31",
      "security_type_desc": "Marketable",
      "security_desc": "Treasury Bonds",
      "avg_interest_rate_amt": "8.450",
      "src_line_nbr": "3",
      "record_fiscal_year": "2001",
      "record_fiscal_quarter": "2",
      "record_calendar_year": "2001",
      "record_calendar_quarter": "1",
      "record_calendar_month": "01",
      "record_calendar_day": "31"
    }
  ]
}