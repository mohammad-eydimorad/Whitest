Feature: Users can register in web site
	In order to use web site
	As a user
	I want to be able to register

@mytag
Scenario: Registration
	Given I want to register with the following details :
	| Key             | Value   |
	| Email           | a@a.com |
	| Password        | 123456  |
	| ConfirmPassword | 123456  |
	When I press submit
	Then I should be given access to the site
