Feature: _08_Confirm Invert Currencies Button Functionality

Scenario: Confirm Invert Currencies button functions as expected
	Given Navigate To basqar
	When Confirm you are on the Xe Currency Converter page
	And Enter "<Amount>" and, "<fromCurrency>" and "<toCurrency>"
	And Click Convert button
	Then User should see converted amount in "<toCurrencyName>"
	And Click Invert Currencies Button
	Then User should see swapped amount in "<fromCurrencyName>"

Examples: 
| Amount    | fromCurrency | fromCurrencyName |toCurrency    | toCurrencyName   |
| 16        | EUR          | Euro			  | USD          | US Dollar        |
| 456       | GBP          | British Pounds   | CAD          | Canadian Dollar  |
| 1456      | THB          | Thai Baht        | JPY          | Japanese Yen     |
