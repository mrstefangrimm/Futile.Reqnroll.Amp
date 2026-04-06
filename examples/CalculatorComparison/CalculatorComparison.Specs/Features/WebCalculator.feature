Feature: Web Calculator
Example of a test for https://webcalculator.netlify.app/.

Scenario: Add two numbers
    Given the web calculator
    And the number "12" is entered
    And Plus is pressed
    And the number "10" is entered
    When Equal is pressed
    Then the result is 22
