Feature: Web Calculator

Scenario: Add two numbers
    Given the web calculator
    And the number "12" is entered
    And Plus is pressed
    And the number "10" is entered
    When Equal is pressed
    Then the result is 22
