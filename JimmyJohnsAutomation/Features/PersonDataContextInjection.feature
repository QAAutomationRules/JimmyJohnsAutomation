Feature: PersonDataContextInjection
	
	As a QA Automation person
	I want to see an example of how to use context injection

@TestContextInjection
Scenario: Use Context Injection Data to create a Jimmy Johns Account
	Given I have a first name "Jimmy" and a last name "Johns"
	And I go to the Jimmy John Home Page
	And I go to the Create account page
	Then the First Name and Last Name may be shared


@TestContextInjection
Scenario: Use Context Injection Data to Populate Phone Field on Create Account Page
	Given I have a phone number "3039229911"
	And I go to the Jimmy John Home Page
	And I go to the Create account page
	Then the phone number is added to the phone number field