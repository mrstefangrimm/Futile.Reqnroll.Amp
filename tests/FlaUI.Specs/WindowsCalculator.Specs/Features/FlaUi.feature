Feature: FlaUI
The Windows calculator opens and mathematical operation are correct

Scenario: Add two numbers
	Given the number "12" is entered
	And Plus is pressed
	And the number "10" is entered
	When Equal is pressed
	Then the result is 22
