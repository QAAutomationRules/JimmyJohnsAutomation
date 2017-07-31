Feature: PersonDataContextInjection
	
	As a math idiot
	I want to be told the sum of two numbers

@TestContextInjection
Scenario: Get Name from Context Injection Data
	Given I have a first name "Jimmy" and a last name "Johns"
	And I go to the Jimmy John Home Page
	And I go to the Create account page
	Then the First Name and Last Name may be shared
