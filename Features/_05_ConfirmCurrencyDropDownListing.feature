Feature: _05_Confirm Source And Target Currency Dropdowns Listings

Scenario: Confirm Source Currency Dropdown First List Popular Currencies
	Given Navigate To basqar
	When Confirm you are on the Xe Currency Converter page
	And Click Source Currency Dropdown
	Then Take screenshot of Source Currency Dropdown to confirm listing

Scenario: Confirm Target Currency Dropdown First List Popular Currencies
	Given Navigate To basqar
	When Confirm you are on the Xe Currency Converter page
	And Click Target Currency Dropdown
	Then Take screenshot of Target Currency Dropdown to confirm listing
