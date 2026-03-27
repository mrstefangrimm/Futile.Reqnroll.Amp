Feature: Four Calculators
Example of a test with four calculators.

Scenario: Add two numbers
    Given the four Calculator
    And the first number for WPF is 50
    And the first number for Futile is 40
    And the first number for StoreApp is "30"
    And the first number for WebCalc is "20"
    And Plus is pressed in StoreApp and WebCalc
    And the second number for WPF is 20
    And the second number for Futile is 30
    And the second number for StoreApp is "40"
    And the second number for WebCalc is "50"
    When Add is pressed in WPF and Futile
    And  Equal is pressed for StoreApp and WebCalc
    Then the result in all should be 70
