Feature: FlaUI Error Screen Capture
An error in a scenario creates an screenshot of the last successful step

Scenario: Add two numbers with invalid expected result
    Given the first number is 50
    And the second number is 50
    When the two numbers are added
    Then the result should be 110

Scenario: Enter two number without calculation
    Given the first number is 50
    When the two numbers are added
    Then the result should be 100
