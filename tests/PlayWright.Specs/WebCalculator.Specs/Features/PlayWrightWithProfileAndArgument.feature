Feature: PlayWright with Profile and Argument
The futile calculator uses the selected profile and takes the URL from the argument.

Scenario: Add two numbers setting the URL from a variable
    Given slowmo local profile is selected and the URL is "https://futile-calculator.netlify.app/"
    And the first number is 50
    And the second number is 70
    When the two numbers are added
    Then the result should be 120
