Feature: _02_Convert Currency in Decimal Amounts

Scenario: Convert decimal amount between different currencies
	Given Navigate To basqar
	When Confirm you are on the Xe Currency Converter page
	And Enter "<Amount>" and, "<fromCurrency>" and "<toCurrency>"
	And Click Convert button
	Then User should see converted amount in "<toCurrencyName>"

Examples: 
| Amount       | fromCurrency | toCurrency   | toCurrencyName   |
| 10.8         | EUR          | USD          | US Dollar        |
| 100.97       | THB          | JPY          | Japanese Yen     |
| 10000.646    | EUR          | NOK          | Norwegian Krone  |
| 10.5781      | GBP          | INR          | Indian Rupee     |
| 10000.345675 | GBP          | INR          | Indian Rupee     |
| 23.4638391   | HKD          | CAD          | Canadian Dollar  |
							 