Feature: _07_Confirm Invalid Amount Error Message

Scenario: Confirm invalid amount error message displayed
	Given Navigate To basqar
	When Confirm you are on the Xe Currency Converter page
	And Enter "<Amount>" and, "<fromCurrency>" and "<toCurrency>"
	And Click Convert button
	Then User should see invalid amount error

Examples: 
| Amount     | fromCurrency | toCurrency   | toCurrencyName   |
| Beer       | EUR          | USD          | US Dollar        |
| Music      | GBP          | CAD          | Canadian Dollar  |
