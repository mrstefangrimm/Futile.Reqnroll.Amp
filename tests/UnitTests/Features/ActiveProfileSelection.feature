Feature: ActiveProfileSelection

Selection of the profile in reqnroll.ampsettings.json

Scenario: One WebApi profile is defined and no name is provided
    Given WebApi profile is defined in reqnroll.ampsettings.json
    When no name is provided
    Then the profile should be selected

Scenario: One WebApi profile is defined and correct name is provided
    Given WebApi profile is defined in reqnroll.ampsettings.json
    When no name is provided
    Then the profile should be selected
