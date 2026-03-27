Feature: PlayWright Minimal
The futile calculator opens and mathematical operation are correct

Scenario: Add two numbers
    Given the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120

Scenario Outline: Add two numbers permutations
    Given the first number is <FirstNumber>
    And the second number is <SecondNumber>
    When the two numbers are added
    Then the result should be <ExpectedResult>

Examples:
    | FirstNumber | SecondNumber | ExpectedResult |
    |           0 |            0 |              0 |
    |          -1 |           10 |              9 |
    |           6 |            9 |             15 |
