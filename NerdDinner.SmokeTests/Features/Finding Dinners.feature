Feature: Finding Dinners
	In order to meet new people
	As a nerd
	I'd like to join a dinner with other nerds

@ignore
Scenario: Finding upcoming dinners	
	Given I have scheduled a dinner for Barbara's birthday
	When Barbara checks the upcoming dinners
	Then She should be able to find the dinner
