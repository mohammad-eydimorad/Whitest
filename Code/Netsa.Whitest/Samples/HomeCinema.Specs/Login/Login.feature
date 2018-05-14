Feature: Users can log into the website
	In order to use web site
	As a user
	I want to be able to log in

@UI
Scenario: Registration
	Given I have already registered with following information :
	| Key             | Value   |
	| Email           | a@a.com |
	| Password        | 123456  |
	| ConfirmPassword | 123456  |
	When I log in
	Then I should be given access to the site