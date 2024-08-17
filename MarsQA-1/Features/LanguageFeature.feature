Feature: Language

As a user, I need to manage my language details in my profile
so that I can perform actions such as add, edit, or delete my language records

@Lang
Scenario Outline:1 Add Languages and language level for user profile
	Given When i Login to the Application and navigates to language section
	When i add <language> and <languagelevel> 
	Then <language> and <languagelevel> should be added succesfully

	Examples: 
	| language  | languagelevel |
	| 'Eng'| 'Fluent'|  
	| 'Ping'| 'Fluent'|  
	| 'Sing'| 'Fluent'|  

	Scenario Outline: 2 Edit Languages and Language level
	Given   User is logged in and navigates to profile 
	When    User edits the record with <newlanguage> and <newlanguagelevel> 
	Then    profile gets updated with modified <newlanguage> and <newlanguagelevel> values

	Examples: 
	| newlanguage | newlanguagelevel |
	| 'Hindi' | 'Basic' |

	Scenario Outline: 3 Delete Languages from User Profile
	Given   User is logged in and navigates to delete section
	When    User deletes <language> from profile
	Then    <language> Should be deleted

	Examples: 
	| language |
	| 'Hindi'  |
	
	Scenario Outline: 4 Add Language record with invalid data
	Given  User is logged in and navigates to profile
	When User tries to add new record with invalid data <language> and <languagelevel>
	Then language record should not be added
	Examples: 
	| language | languagelevel |
	|    ''      |  'Conversational' |
	|    'French'      |    ''          |
	|    ''      |    ''          |

	Scenario Outline: 5 Add Language record with already existing data
	Given  User is logged in and navigates to profile
	When User tries to add new record with already existing data <language> and <languagelevel>
	Then  user should not be able to add record
	Examples: 
	| language | languagelevel |
	| 'Ping'| 'Fluent'| 
	



	Scenario: 6 Edit Language record without changing data
	Given  User is logged in and navigates to profile
	When User tries to update existing record without editing language or languagelevel
	Then User Should get an error displayed and record is not modified
	






