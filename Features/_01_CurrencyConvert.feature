Feature: _01_Convert Currency

Scenario: Convert entered amount between different currencies
	Given Navigate To basqar
	When Confirm you are on the Xe Currency Converter page
	And Enter "<Amount>" and, "<fromCurrency>" and "<toCurrency>"
	And Click Convert button
	Then User should see converted amount in "<toCurrencyName>"

Examples: 
| Amount    | fromCurrency | toCurrency   | toCurrencyName   |
| 1         | EUR          | USD          | US Dollar        |
| 1         | GBP          | CAD          | Canadian Dollar  |
| 1         | THB          | JPY          | Japanese Yen     |
| 10000000  | EUR          | USD          | US Dollar        |
| 10000000  | GBP          | CAD          | Canadian Dollar  |
| 10000000  | HKD          | NOK		  | Norwegian Krone  |


