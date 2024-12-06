Feature: _03_Confirm Full Conversion Amount and Exchange Rate Between Currencies Displayed

Scenario: Confirm converted amount and exchange rate displayed
	Given Navigate To basqar
	When Confirm you are on the Xe Currency Converter page
	And Enter "<Amount>" and, "<fromCurrency>" and "<toCurrency>"
	And Click Convert button
	Then User should see converted amount in "<toCurrencyName>"
	And User should see exchange rate between source "<fromCurrency>" and target "<toCurrency>"
	And User should see exchange rate between target "<toCurrency>" and source "<fromCurrency>"

Examples: 
| Amount    | fromCurrency | toCurrency   |  toCurrencyName          | 
| 10        | AUD          | CNY          |  Chinese Yuan Renminbi   |	
| 100       | HKD          | MXN          |  Mexican Peso			 |	
| 10000     | THB          | SGD          |  Singapore Dollar		 |	
