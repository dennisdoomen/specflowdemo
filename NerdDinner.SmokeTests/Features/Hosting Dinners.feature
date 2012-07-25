Feature: Hosting Dinners
	In order to increase my business network
	As a entrepeneur
	I want to host dinners with interesting people from the community

@mytag
Scenario: Attempting to host a dinner without being logged on
	Given I am not logged on
	When I try to host a dinner
	Then I should be forced to log on first
