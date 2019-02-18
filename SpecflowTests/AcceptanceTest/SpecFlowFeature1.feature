Feature: SpecFlowFeature1
	In order to update my profile 
	As a skill trader
	I want to add the languages that I know

@mytag
Scenario: Check if user could able to add a language 
	Given I clicked on the Language tab under Profile page
	When I add a new language
	Then that language should be displayed on my listings

	Scenario: Check if user could able to edit the language 
    Given I clicked on the Language tab under Profile page
    When I edit the added language
    Then that language should be edited and displayed on my listings
    
    Scenario: Check if user could able to delete the language 
    Given I clicked on the Language tab under Profile page
    When I delete the added language
    Then that language should be deleted from the listings
    
    Scenario: Check if user could able add a language without choosing the language level
    Given I clicked on the Language tab under Profile page
    When I add a new language
    When I didnot choose the language level
    Then a popup should appear on the screen 
    Then the language should not be displayed on my listings
    
    Scenario: Check if user could able to cancel the language
    Given I clicked on the Language tab under Profile page
    When I add a new language
    When I clicked on the cancel button
    Then the language should not be displayed on my listings
	