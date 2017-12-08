Feature: Providing a secure password when registering
	In order to avoid hackers compromising member accounts
	As the systems administrator
	I want new members to provide a secure password when they register

Scenario: Password is too short
	Given I want to register with the following details :
	| Key             | Value   |
	| Email           | b@b.com |
	| Password        | 12345  |
	| ConfirmPassword | 12345  |
	When I press submit
	Then I should be inform that password is too short


Scenario: Password requires digit
	Given I want to register with the following details :
	| Key             | Value   |
	| Email           | c@c.com |
	| Password        | abcdefg  |
	| ConfirmPassword | abcdefg  |
	When I press submit
	Then I should be inform that password should have at least one digit