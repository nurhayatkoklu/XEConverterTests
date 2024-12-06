Currency Converter Automation Tests

Project Overview
This project automates the testing of a currency conversion component, ensuring it meets the specified user story and acceptance criteria. The tests are developed using SpecFlow for BDD (Behavior-Driven Development) and Selenium WebDriver for browser automation. The component under test allows users to perform forex conversions, validate numeric input, and swap currencies while providing accurate exchange rate details.

Features
User Story
As a user, I should be able to perform forex conversions using a converter widget. The component allows:

Specifying an amount, source, and target currency for conversion.
Displaying the conversion results with accurate exchange rates.
Handling invalid and negative input values.
Swapping source and target currencies.
Updating the page URL based on the conversion.
Key Acceptance Criteria
Display of full conversion amount and single-unit conversion rate.
Mathematical correctness of conversions.
Alphabetical and popularity-based dropdown sorting.
Handling invalid and negative numeric values with error messages.
URI updates reflecting conversions.
Project Structure

1. Feature Files
Located in the root folder, these files contain scenarios written in Gherkin syntax that outline the test cases.

Example: _01_CurrencyConvert.feature, _02_CurrencyConvertIDecimalAmounts.feature, etc.

2. Step Definitions
The logic that binds Gherkin steps to Selenium methods.

File: ConvertCurrencyTestSteps.cs

3. Page Object Model
Encapsulation of UI element locators and actions related to the currency converter.

File: CurrencyConverterPage.cs

4. Helpers
Utility methods for common actions such as sending keys, clicking, and taking screenshots.

File: Helpers.cs

5. Driver Initialization
Setup and teardown for the WebDriver using Chrome.

File: GetWebDriver.cs, SetUp.cs

6. Hooks
Pre- and post-scenario steps, such as initializing and quitting the WebDriver.

File: Hook.cs

Setup and Execution

Prerequisites
.NET SDK (version 6.0 or above)
Chrome Browser and compatible ChromeDriver executable.

Installation
Clone the repository.
Add the ChromeDriver executable to the Drivers folder.
Install required NuGet packages:
	Selenium.WebDriver
	SpecFlow
	NUnit
Execution
Open the project in an IDE (e.g., Visual Studio).
Build the solution.
Run tests using the NUnit Test Runner.

Usage and Key Highlights

Running Tests
Tests can be executed individually or as a suite using the Test Explorer in Visual Studio.

Debugging
Use Console.WriteLine or NUnit assertions in step definitions for validation during development.

Screenshots
Screenshots of dropdown listings are stored in the ScreenShots folder for validation.

Extent Report
View the detailed HTML report of the final test executions located in \bin\Debug\net6.0\TestResults.html