Feature: _06_Confirm Negative Amounts Converted

Scenario: Convert negative amount between different currencies
	Given Navigate To basqar
	When Confirm you are on the Xe Currency Converter page
	And Enter Amount and source and target currency
	And Click Convert button
	And Refresh Page
	And Clear Amount Text Box
	And Enter negative "<Amount>" and, "<fromCurrency>" and "<toCurrency>"
	Then User should see an error message
	Then User should see converted negative amount in "<toCurrencyName>"

Examples: 
| Amount    | fromCurrency | toCurrency   | toCurrencyName   |
| -456	    | EUR          | USD          | US Dollar        |
| -45.93    | GBP          | CAD          | Canadian Dollar  |
| -103.5    | HKD          | NOK		  | Norwegian Krone  |