Feature: _10_Confirm User Can Access Conversion Page Directly

Scenario: Convert entered amount between different currencies
	Given Navigate To basqar
	When Confirm you are on the Xe Currency Converter page
	And Enter "<Amount>" and, "<fromCurrency>" and "<toCurrency>"
	And Click Convert button
	And Get URL and go to this URL
	Then Confirm that you are on the correct page by confirming "<toCurrencyName>"


Examples: 
| Amount    | fromCurrency | fromCurrencyName |toCurrency    | toCurrencyName   |
| 16.60     | EUR          | Euro			  | USD          | US Dollar        |
| 378       | GBP          | British Pounds   | CAD          | Canadian Dollar  |
| 3097      | THB          | Thai Baht        | JPY          | Japanese Yen     |