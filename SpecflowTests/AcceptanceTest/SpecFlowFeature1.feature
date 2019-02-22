Feature: SpecFlowFeature1
	In order to update my profile 
	As a skill trader
	I want to add the skill that I know

@mytag
Scenario: Check if user is able to add a language 
	Given I clicked on the language tab under Profile page
	When I add a new language
	Then that language should be displayed on my listings

	Scenario: Check if user is able to edit the language 
    Given I clicked on the language tab under Profile page
    When I edit the added language
    Then that language should be edited and displayed on my listings
    
    Scenario: Check if user is able to delete the language 
    Given I clicked on the language tab under Profile page
    When I delete the added language
    Then that language should be deleted from the listings
    
   