Feature: Futile-Calculator

Scenario: Add two numbers
    Given the futile calculator
    And the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120
