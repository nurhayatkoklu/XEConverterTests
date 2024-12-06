Feature: _09_Confirm URL Updated After Conversion

Scenario: Confirm URL is being updated after a conversion
	Given Navigate To basqar
	When Confirm you are on the Xe Currency Converter page
	And Enter "<Amount>" and, "<fromCurrency>" and "<toCurrency>"
	And Click Convert button
	Then URL should contain "<Amount>", "<fromCurrency>" in From and "<toCurrency>" in To
	And Refresh Page
	And Click Invert Currencies Button
	Then URL should be updated, "<Amount>" should stay as it is "<fromCurrency>" and "<toCurrency>" should be swapped	

Examples: 
| Amount    | fromCurrency |  toCurrency   |
| 16        | EUR          |  USD          | 
| 456.65    | GBP          |  CAD          | 
| 1456      | THB          |  JPY          | 