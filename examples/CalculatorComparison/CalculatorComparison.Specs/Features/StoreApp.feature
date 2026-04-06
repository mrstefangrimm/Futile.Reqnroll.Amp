Feature: StoreApp Windows Calculator
Example of a test for the Windows Calculator.

Scenario: Add two numbers
	Given the Windows calculator
	And the number "12" is entered
	And Plus is pressed
	And the number "10" is entered
	When Equal is pressed
	Then the result is 22
