Feature: Hosting Dinners
	In order to increase my business network
	As a entrepeneur
	I want to host dinners with interesting people from the community

@mytag
Scenario: Attempting to host a dinner as a anonymous user
	Given an anonymous user
	When you want to host a dinner
	Then you should be required to log on first

Scenario: Attempting to host a dinner as a registered user
	Given a registered user
	When you want to host a dinner
	Then you should be able to schedule a dinner

