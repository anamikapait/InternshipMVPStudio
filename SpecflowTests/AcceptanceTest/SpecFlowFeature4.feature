Feature: SpecFlowFeature4
	In order to update my profile 
	As a skill trader
	I want to add the Certification

@mytag
Scenario: 1 Check if user could able to add certification 
	Given I clicked on the certification tab under Profile page
	When I add a new certification
	Then that certification should be displayed on my listings

	Scenario: 2 Check if user could able to edit the certification 
    Given I clicked on the certification tab under Profile page
    When I edit the added certification
    Then that certification should be edited and displayed on my listings
    
    Scenario: 3 Check if user could able to delete the certification 
    Given I clicked on the certification tab under Profile page
    When I delete the added certification
    Then that certification should be deleted from the listings
