﻿Feature: Create a Jimmy Johns user account
	
	As a Jimmy John's customer
	I want to be able to create a user account

Background: Navigate to the Jimmy John Home Page
	Given I go to the Jimmy John Home Page

@SMOKE
Scenario: Create a Jimmy Johns user account
	Given I go to the Create account page
	When I create a new account with a Page Object
	Then the Jimmy John user is created


@Navigation
Scenario: Navigate to Create user account
	Given I go to the Login Page
	When I click on the Create Account Link
	Then I view the Create Account Page


@SMOKE
Scenario: Add a Jimmy Johns user account with NBuilder Data
	Given I go to the Create account page
	When I create a new account with an NBuilder Person
	Then the Jimmy John user is created


@SMOKE
Scenario: Add a Jimmy Johns user account with NBuilder List Data
	Given I go to the Create account page
	When I create a new account with NBuilder List of Person Data
	Then the Jimmy John user is created