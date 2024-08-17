Feature: MarsSiginFeature

As a Mars Application user I want to be able to update my profile with languages and skills I know.
So that the people seeking for skills and languages can look my profile and reach out to me.

Scenario: Signin to Mars Application 
	Given  User enters valid Emailaddress and Password
	Then   User Must be loggedin to the Application and able to see profile Page
	