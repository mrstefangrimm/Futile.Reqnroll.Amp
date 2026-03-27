Feature: PlayWright with Profile
The futile calculator uses the selected profile. It takes the first profile is none is selected.

Scenario: Add two numbers without profile
    Given the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120

Scenario: Add two numbers headless
    Given headless profile is selected
    And the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120

Scenario: Add two numbers in slow motion
    Given profile is selected with slowmo
    And the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120

Scenario: Add two numbers using Windows chrome installation
    Given profile is selected with installed chrome
    And the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120
