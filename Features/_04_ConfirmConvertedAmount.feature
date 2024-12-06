Feature: _04_Confirm Converted Amount

Scenario: Confirm converted amount is mathematically correct
	Given Navigate To basqar
	When Confirm you are on the Xe Currency Converter page
	And Enter "<Amount>" and, "<fromCurrency>" and "<toCurrency>"
	And Click Convert button
	Then User should see converted amount in "<toCurrencyName>"
	Then Converted amount "<Amount>" from "<fromCurrency>" to "<toCurrency>" should be mathematically correct

Examples: 
| Amount    | fromCurrency | toCurrency   |  toCurrencyName          | 
| 10        | AUD          | CNY          |  Chinese Yuan Renminbi   |	
| 100       | HKD          | MXN          |  Mexican Peso			 |	
| 123       | GBP          | CAD          |  Canadian Dollar         |	
| 2278      | MXN          | SGD          |  Singapore Dollar    	 |	
| 34289     | TRY          | INR          |  Indian Rupee       	 |

