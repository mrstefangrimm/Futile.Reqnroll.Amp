Feature: WPF Calculator
Example of a test for a Windows application written with WPF.

Scenario: Add two numbers
    Given WPF Calculator
    And the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120
