Feature: Skills

As a User i Should be able to maintain my skills in my profile  
so that who ever is intrested in learning can contact me
@Skills
Scenario Outline: 1 Add Skills and SkillLevel for for User Profile
	Given User logs into the application and navigates to Skills Section
	When User adds <Skill> <level> 
	Then Profile is updated with <Skill> and <level>
	Examples: 
	| Skill  | level |
	| 'Java'| 'Beginner'|  
	| 'Selenium'| 'Intermediate'|  
	| 'Postman'| 'Expert'|  

	Scenario Outline: 2 Edit Skills and Skilllevel
	Given   User is logged in and navigates to profile skill section
	When    User updates the record with <newSkill> and <newlevel> 
	Then    profile gets updated with updated <newSkill> and <newlevel> 

	Examples: 
	| newSkill | newlevel |
	| 'Python' | 'Beginner' |

	Scenario Outline: 3 Delete Skills from User Profile
	Given   User is logged in and navigates to Skill delete section
	When    User deletes <Skill> from skills
	Then    <Skill> Should be deleted from list

	Examples: 
	| Skill  |
	| 'Postman' |
	

	Scenario Outline: 4 Add Skill record with invalid data
	Given  User is logged in and navigates to profile skill section
	When User tries to add new skill record with invalid data <Skill> and <level>
	Then Skill record should not be added
	Examples: 
	| Skill | level |
	|    ''      |  'Beginner' |
	|    'C'      |    ''          |
	|    ''      |    ''          |

	Scenario Outline: 5 Add Skill record with already existing data
	Given  User is logged in and navigates to profile skill section
	When User tries to add new skill record with already existing data <Skill> and <level>
	Then  User should not be able to add Skill record  
	Examples: 
	| Skill | level |
	| 'Selenium'| 'Intermediate'|  
	
	Scenario: 6 Edit Skill record without changing data
	Given  User is logged in and navigates to profile skill section
	When User tries to update existing skill record without editing Skill or Skilllevel
	Then User Should get an error record is not modified
	

