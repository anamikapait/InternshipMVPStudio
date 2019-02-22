Feature: SpecFlowFeature2
	In order to update my profile 
	As a skill trader
	I want to add the Skill that I know

@mytag
Scenario: Check if user could able to add a Skill 
	Given I clicked on the Skill tab under Profile page
	When I add a new Skill
	Then that Skill should be displayed on my listings

	Scenario: Check if user could able to edit the Skill 
    Given I clicked on the Skill tab under Profile page
    When I edit the added Skill
    Then that Skill should be edited and displayed on my listings
    
    Scenario: Check if user could able to delete the Skill 
    Given I clicked on the Skill tab under Profile page
    When I delete the added Skill
    Then that Skill should be deleted from the listings
    