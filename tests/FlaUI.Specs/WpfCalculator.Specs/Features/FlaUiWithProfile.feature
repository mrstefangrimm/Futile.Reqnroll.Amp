Feature: FlaUI with Profile
The WPF calculator uses the selected profile. It takes the first profile is none is selected.

Scenario: Add two numbers
    Given the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120

Scenario: Add two numbers with commandline argument for the WPF calculator
    Given profile with argument is selected
    And the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120
    And the title is set to the profile's argument
